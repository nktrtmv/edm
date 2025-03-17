using Dapper;

using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Configuration;
using Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Get;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Search;
using Edm.Document.Searcher.Infrastructure.Options;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Get;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Search;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents;

internal sealed class SearchDocumentsRepository(IConfiguration configuration) : ISearchDocumentsRepository
{
    private static HashSet<DomainId> KnownDomains = [DomainId.Parse(DomainId.ContractsDomain)];
    private DbOptions Options { get; } = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);

    public async Task<ConcurrencyToken<SearchDocument>> Upsert(SearchDocument document, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var documentDb = SearchDocumentDbFromDomainConverter.FromDomain(document);

        await EnsurePartitionExists(document.DomainId, cancellationToken);

        var upsert = DocumentRepositoryQueries.Upsert(documentDb, cancellationToken);
        var concurrencyToken = await connection.QuerySingleAsync<DateTime>(upsert);

        ConcurrencyToken<SearchDocument> result = ConcurrencyTokenConverterFrom<SearchDocument>.FromUnspecifiedUtcDateTime(concurrencyToken);

        return result;
    }

    public async Task<Id<SearchDocument>[]> Search(SearchDocumentsQuery query, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var queryDb = SearchDocumentsQueryDbConverter.FromDomain(query);

        IEnumerable<string> documentsIds = await connection.QueryAsync<string>(DocumentRepositoryQueries.Search(queryDb, cancellationToken));

        Id<SearchDocument>[] result = documentsIds.Select(IdConverterFrom<SearchDocument>.FromString).ToArray();

        return result;
    }

    public async Task<SearchDocument[]> Get(GetDocumentsQuery query, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var queryDb = GetDocumentsQueryDbConverter.FromDomain(query);

        IEnumerable<SearchDocumentDb> documents = await connection.QueryAsync<SearchDocumentDb>(DocumentRepositoryQueries.Get(queryDb, cancellationToken));

        SearchDocument[] result = documents.Select(SearchDocumentDbToDomainConverter.ToDomain).ToArray();

        return result;
    }

    public async Task DeleteByIds(DomainId domainId, HashSet<Id<SearchDocument>> documentIds, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var query = DocumentRepositoryQueries.Delete(domainId, documentIds, cancellationToken);
        await connection.ExecuteAsync(query);
    }

    public async Task<SearchDocument?> Get(DomainId domainId, Id<SearchDocument> documentId, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var id = IdConverterTo.ToString(documentId);

        var document = await connection.QuerySingleOrDefaultAsync<SearchDocumentDb>(DocumentRepositoryQueries.Get(domainId.Value, id, cancellationToken));

        var result = NullableConverter.Convert(document, SearchDocumentDbToDomainConverter.ToDomain);

        return result;
    }

    public async Task<SearchDocument> GetRequired(DomainId domainId, Id<SearchDocument> documentId, CancellationToken cancellationToken)
    {
        var result = await Get(domainId, documentId, cancellationToken);

        if (result is null)
        {
            throw new ApplicationException($"Required Document with domainId: {domainId} and id: {documentId} is not found");
        }

        return result;
    }

    private async Task EnsurePartitionExists(DomainId domainId, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        if (KnownDomains.Contains(domainId))
        {
            return;
        }

        var createPartition = DocumentRepositoryQueries.CreatePartition(domainId.Value, cancellationToken);

        try
        {
            await connection.ExecuteAsync(createPartition);
        }
        catch (PostgresException e) when (e.SqlState == "42P07")
        {
            // duplicate table -> already exists
        }

        KnownDomains = KnownDomains.Concat([domainId]).ToHashSet();
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
