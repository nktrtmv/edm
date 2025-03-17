using Dapper;

using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents;

internal static class DocumentRepositoryQueries
{
    internal static CommandDefinition Upsert(DocumentDb document, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO documents
            (
                id,
                template_id,
                template_system_name,
                status_id,
                data,
                created_by_id,
                updated_by_id,
                created_datetime,
                updated_datetime
            )
            VALUES
            (
                @id,
                @template_id,
                @template_system_name,
                @status_id,
                @data,
                @created_by_id,
                @updated_by_id,
                @created_datetime,
                @updated_datetime
            )
            ON CONFLICT (id) DO UPDATE
            SET
                status_id = excluded.status_id,
                data = excluded.data,
                updated_by_id = excluded.updated_by_id,
                updated_datetime = excluded.updated_datetime,
                concurrency_token = TIMEZONE('utc'::TEXT, CURRENT_TIMESTAMP)
            WHERE
                documents.id = @id
                and documents.concurrency_token = @validate_concurrency_token
            RETURNING documents.concurrency_token;
            """,
            new
            {
                id = document.Id,
                template_id = document.TemplateId,
                template_system_name = document.TemplateSystemName,
                status_id = document.StatusId,
                data = document.Data,
                created_by_id = document.CreatedById,
                updated_by_id = document.UpdatedById,
                created_datetime = DateTime.SpecifyKind(document.CreatedDateTime, DateTimeKind.Utc),
                updated_datetime = DateTime.SpecifyKind(document.UpdatedDateTime, DateTimeKind.Utc),
                validate_concurrency_token = DateTime.SpecifyKind(document.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Get(string[] ids, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                d.id,
                t.domain_id,
                d.template_id,
                d.template_system_name,
                d.status_id,
                d.data,
                d.created_by_id,
                d.updated_by_id,
                d.created_datetime,
                d.updated_datetime,
                d.concurrency_token
            FROM documents d
            INNER JOIN document_templates t on d.template_id = t.id
            WHERE d.id = ANY(@ids);
            """,
            new
            {
                ids
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition DeleteByIds(DomainId domainId, IReadOnlyCollection<Id<Document>> ids, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            WITH cte AS (SELECT d.id
                         FROM documents d
                                  INNER JOIN document_templates t on d.template_id = t.id
                         WHERE t.domain_id=@domain_id AND d.Id=ANY(@ids))
            DELETE FROM documents WHERE id=ANY(SELECT id FROM cte)
            """,
            new
            {
                ids = ids.Select(x => x.Value).ToArray(),
                domain_id = domainId.Value
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetAllIds(DomainId domainId, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                d.id
            FROM documents d
            WHERE d.domain_id = @domain_id;
            """,
            new
            {
                domain_id = domainId.Value
            },
            cancellationToken: cancellationToken);
    }
}
