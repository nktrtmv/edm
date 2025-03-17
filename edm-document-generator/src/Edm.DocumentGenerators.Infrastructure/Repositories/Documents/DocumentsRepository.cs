using Dapper;

using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Configuration.Fetchers;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;
using Edm.DocumentGenerators.Infrastructure.Options;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents;

internal sealed class DocumentsRepository : IDocumentsRepository
{
    public DocumentsRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);
    }

    private DbOptions Options { get; }

    public async Task<Document?> Get(Id<Document> documentId, CancellationToken cancellationToken)
    {
        Document[] documents = await Search([documentId], cancellationToken);

        return documents.SingleOrDefault();
    }

    public async Task<Document> GetRequired(Id<Document> documentId, CancellationToken cancellationToken)
    {
        Document? result = await Get(documentId, cancellationToken);

        if (result is null)
        {
            throw new ApplicationException($"Required Document (id:{documentId}) is not found.");
        }

        return result;
    }

    public async Task<Document> GetRequired(DomainId domainId, Id<Document> documentId, CancellationToken cancellationToken)
    {
        Document result = await GetRequired(documentId, cancellationToken);

        if (result.DomainId != domainId)
        {
            throw new ApplicationException($"Required Document (id:{documentId}) (domainId:{domainId}) is not found.");
        }

        return result;
    }

    public async Task<Document[]> Search(HashSet<Id<Document>> documentsIds, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        string[] ids = documentsIds.Select(IdConverterTo.ToString).ToArray();

        IEnumerable<DocumentDb> document = await connection.QueryAsync<DocumentDb>(DocumentRepositoryQueries.Get(ids, cancellationToken));

        Document[] result = document.Select(DocumentDbToDomainConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<Id<Document>[]> GetAllIds(DomainId domainId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        IEnumerable<string> document = await connection.QueryAsync<string>(DocumentRepositoryQueries.GetAllIds(domainId, cancellationToken));

        Id<Document>[] result = document.Select(IdConverterFrom<Document>.FromString).ToArray();

        return result;
    }

    public async Task<ConcurrencyToken<Document>> Upsert(Document document, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        DocumentDb documentDb = DocumentDbFromDomainConverter.FromDomain(document);

        var concurrencyToken = await connection.QuerySingleAsync<DateTime>(DocumentRepositoryQueries.Upsert(documentDb, cancellationToken));

        ConcurrencyToken<Document> result = ConcurrencyTokenConverterFrom<Document>.FromUnspecifiedUtcDateTime(concurrencyToken);

        return result;
    }

    public async Task DeleteByIds(DomainId domainId, HashSet<Id<Document>> documentsIds, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = DocumentRepositoryQueries.DeleteByIds(domainId, documentsIds, cancellationToken);

        await connection.QueryAsync(query);
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
