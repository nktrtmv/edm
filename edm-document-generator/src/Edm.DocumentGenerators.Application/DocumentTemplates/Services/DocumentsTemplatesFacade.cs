using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Services;

internal sealed class DocumentsTemplatesFacade(IDocumentsTemplatesRepository templates)
{
    private const int RetryCount = 10;
    private const int BatchSize = 75;

    internal async Task MigrateAll(DomainId domainId, CancellationToken cancellationToken)
    {
        Id<DocumentTemplate>[] ids = await templates.GetAllIds(domainId, cancellationToken);

        foreach (Id<DocumentTemplate>[] chunk in ids.Chunk(BatchSize))
        {
            IEnumerable<Task<DocumentTemplate>> tasks = chunk.Select(id => GetRequired(domainId, id, cancellationToken));

            await Task.WhenAll(tasks);
        }
    }

    internal async Task<DocumentTemplate?> Get(DomainId domainId, Id<DocumentTemplate> templateId, CancellationToken cancellationToken)
    {
        DocumentTemplate? result = await templates.Get(domainId, templateId, cancellationToken);

        if (result is null)
        {
            return null;
        }

        return result;
    }

    internal async Task<DocumentTemplate> GetRequired(DomainId domainId, Id<DocumentTemplate> templateId, CancellationToken cancellationToken)
    {
        DocumentTemplate? result = await Get(domainId, templateId, cancellationToken);

        if (result is null)
        {
            throw new BusinessLogicApplicationException($"Required Document Template (id:{templateId}) is not found.");
        }

        return result;
    }

    internal async Task<DocumentTemplate[]> GetAll(DomainId domainId, GetAllDocumentsTemplatesQueryParams queryParams, CancellationToken cancellationToken)
    {
        DocumentTemplate[] result = await templates.Search(domainId, queryParams, cancellationToken);

        return result;
    }

    internal async Task Delete(DomainId domainId, Id<DocumentTemplate> templateId, Id<User> currentUserId, CancellationToken cancellationToken)
    {
        DocumentTemplate? sourceTemplate = await templates.GetRequired(domainId, templateId, cancellationToken);

        if (sourceTemplate.IsDeleted)
        {
            return;
        }

        DocumentTemplate? templateToDelete = DocumentTemplateFactory.CreateFrom(
            domainId,
            sourceTemplate.Id,
            sourceTemplate.Name,
            sourceTemplate.Status,
            currentUserId,
            sourceTemplate);

        await templates.Delete(templateToDelete, cancellationToken);
    }

    internal async Task<DocumentTemplate> Upsert(DocumentTemplate template, CancellationToken cancellationToken)
    {
        await templates.Upsert(template, cancellationToken);

        DocumentTemplate result = await templates.GetRequired(template.DomainId, template.Id, cancellationToken);

        return result;
    }
}
