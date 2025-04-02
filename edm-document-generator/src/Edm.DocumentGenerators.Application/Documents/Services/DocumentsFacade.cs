using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Services;

internal sealed class DocumentsFacade(
    IDocumentsRepository documentsRepository,
    ApplicationEventsPreparer<Document> preparer,
    ApplicationEventsProcessor<Document> processor,
    ILogger<DocumentsFacade> logger)
{
    private const int RetryCount = 10;
    private const int BatchSize = 30;

    internal async Task ProcessAll(DomainId domainId, CancellationToken cancellationToken)
    {
        Id<Document>[] ids = await documentsRepository.GetAllIds(domainId, cancellationToken);
        ;

        var current = 0;

        do
        {
            Id<Document>[]? batch = ids.Skip(current).Take(BatchSize).ToArray();

            IEnumerable<Task<Document>> tasks = batch.Select(id => GetRequired(id, cancellationToken));

            await Task.WhenAll(tasks);

            current += BatchSize;
        }
        while (ids.Length > current);

        logger.LogInformation("🛠🛠🛠 All documents processed.");
    }

    internal async Task<Document?> Get(Id<Document> documentId, bool skipProcessing, CancellationToken cancellationToken)
    {
        Document? document = await documentsRepository.Get(documentId, cancellationToken);

        if (document is null)
        {
            return null;
        }

        if (skipProcessing)
        {
            return document;
        }

        Document? result = await Process(document, cancellationToken);

        return result;
    }

    internal async Task<Document[]> GetAll(Id<Document>[] documentsIds, bool skipProcessing, CancellationToken cancellationToken)
    {
        Task<Document>[] tasks = documentsIds.Select(d => GetRequired(d, skipProcessing, cancellationToken)).ToArray();

        Document[] result = await Task.WhenAll(tasks);

        return result;
    }

    internal async Task<Document> GetRequired(Id<Document> documentId, CancellationToken cancellationToken)
    {
        Document? result = await GetRequired(documentId, false, cancellationToken);

        return result;
    }

    internal async Task<Document> GetRequired(DomainId domainId, Id<Document> documentId, CancellationToken cancellationToken)
    {
        Document? result = await GetRequired(documentId, false, cancellationToken);

        return result;
    }

    internal async Task<Document> GetRequired(Id<Document> documentId, bool skipProcessing, CancellationToken cancellationToken)
    {
        Document? document = await documentsRepository.GetRequired(documentId, cancellationToken);

        if (skipProcessing)
        {
            return document;
        }

        Document? result = await Process(document, cancellationToken);

        return result;
    }

    internal async Task<Document> GetRequired(DomainId domainId, Id<Document> documentId, bool skipProcessing, CancellationToken cancellationToken)
    {
        Document? document = await documentsRepository.GetRequired(domainId, documentId, cancellationToken);

        if (skipProcessing)
        {
            return document;
        }

        Document? result = await Process(document, cancellationToken);

        return result;
    }

    internal async Task Upsert(Document document, CancellationToken cancellationToken)
    {
        await preparer.Prepare(document.ApplicationEvents, document, cancellationToken);

        document = await Update(document, cancellationToken);

        await Process(document, cancellationToken);
    }

    private async Task<Document> Process(Document document, CancellationToken cancellationToken)
    {
        document = await ProcessApplicationEvents(document, cancellationToken);

        Document? result = await ProcessApplicationEvents(document, cancellationToken);

        return result;
    }

    private async Task<Document> ProcessApplicationEvents(Document document, CancellationToken cancellationToken)
    {
        var exceptions = new List<Exception>();

        for (var i = 0; i < RetryCount; i++)
        {
            if (document.ApplicationEvents.Count == 0)
            {
                return document;
            }

            (bool applicationEventsProcessed, Exception? processException) = await processor.Process(
                document.ApplicationEvents,
                document,
                cancellationToken);

            if (applicationEventsProcessed)
            {
                document.ApplicationEvents.Clear();

                document = await Update(document, cancellationToken);
            }
            else
            {
                exceptions.Add(processException!);
                document = await documentsRepository.GetRequired(document.Id, cancellationToken);
            }
        }

        throw new ApplicationException($"Failed to process application events.\nDocument: {document}", new AggregateException(exceptions));
    }

    private async Task<Document> Update(Document document, CancellationToken cancellationToken)
    {
        await documentsRepository.Upsert(document, cancellationToken);

        Document? result = await documentsRepository.GetRequired(document.Id, cancellationToken);

        return result;
    }
}
