using Dapper;

using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Get;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Search;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents;

internal static class DocumentRepositoryQueries
{
    internal static CommandDefinition CreatePartition(string domainId, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(domainId, out var newPartitionId))
        {
            throw new ApplicationException($"New domain id name must be guid, current: {domainId}");
        }

        return new CommandDefinition(
            $"""
             CREATE TABLE "{newPartitionId}" PARTITION OF all_search_documents FOR VALUES IN ('{newPartitionId}')
             """,
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Upsert(SearchDocumentDb document, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO all_search_documents
            (
                domain_id,
                id,
                template_id,
                attributes_values
            )
            VALUES
            (
                @domain_id,
                @id,
                @template_id,
                @attributes_values::jsonb
            )
            ON CONFLICT (domain_id, id) DO UPDATE
            SET
                attributes_values = @attributes_values::jsonb,
                concurrency_token = timezone('utc'::text, CURRENT_TIMESTAMP)
            WHERE
                all_search_documents.id = @id AND
                all_search_documents.concurrency_token = @concurrency_token
            RETURNING all_search_documents.concurrency_token;
            """,
            new
            {
                domain_id = document.DomainId,
                id = document.Id,
                template_id = document.TemplateId,
                attributes_values = document.AttributesValues,
                concurrency_token = DateTime.SpecifyKind(document.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Search(SearchDocumentsQueryDb query, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            $"""
             SELECT
                 d.id
             FROM all_search_documents d
             WHERE @domain_id = d.domain_id
                   {query.Filters}
             {query.SortParameters}
             LIMIT @limit
             OFFSET @skip;
             """,
            new
            {
                domain_id = query.DomainId,
                limit = query.Limit,
                skip = query.Skip,
                json_condition = query.Filters
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Get(GetDocumentsQueryDb query, CancellationToken cancellationToken)
    {
        var idsSort = query.DocumentsIds.Length > 0 ? "AND id = ANY(@documents_ids)" : "";

        return new CommandDefinition(
            $"""
             SELECT
                 d.id,
                 d.template_id,
                 d.domain_id,
                 d.attributes_values,
                 d.concurrency_token
             FROM all_search_documents d
             WHERE @domain_id = d.domain_id
                   {idsSort}
                   {query.Filters}
             {query.SortParameters}
             LIMIT @limit
             OFFSET @skip;
             """,
            new
            {
                domain_id = query.DomainId,
                limit = query.Limit,
                skip = query.Skip,
                json_condition = query.Filters,
                documents_ids = query.DocumentsIds
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Delete(DomainId domainId, HashSet<Id<SearchDocument>> documentIds, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            DELETE FROM all_search_documents WHERE domain_id=@domain_id AND id=ANY(@ids)
            """,
            new
            {
                domain_id = domainId.Value,
                ids = documentIds.Select(x => x.Value).ToArray()
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Get(string domainId, string id, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                d.id,
                d.template_id,
                d.domain_id,
                d.attributes_values,
                d.concurrency_token
            FROM all_search_documents d
            WHERE d.domain_id = @domain_id AND d.id = @id
            """,
            new
            {
                id,
                domain_id = domainId
            },
            cancellationToken: cancellationToken);
    }
}
