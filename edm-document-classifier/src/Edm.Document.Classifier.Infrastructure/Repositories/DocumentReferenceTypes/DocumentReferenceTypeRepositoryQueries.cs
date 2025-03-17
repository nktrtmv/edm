using Dapper;

using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes;

internal static class DocumentReferenceTypeRepositoryQueries
{
    internal static CommandDefinition Upsert(DocumentReferenceTypeDb db, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO document_reference_types
            (
                id,
                reference_type_id,
                domain_id,
                display_name,
                data,
                created_by_id,
                updated_by_id,
                created_datetime,
                updated_datetime,
                is_deleted,
                version
            )
            VALUES
            (
                @id,
                @reference_type_id,
                @domain_id,
                @display_name,
                @data,
                @created_by_id,
                @updated_by_id,
                @created_datetime,
                @updated_datetime,
                @is_deleted,
                @version
            )
            ON CONFLICT (id) DO UPDATE
            SET
                domain_id = excluded.domain_id,
                display_name = excluded.display_name,
                data = excluded.data,
                updated_by_id = excluded.updated_by_id,
                updated_datetime = excluded.updated_datetime,
                concurrency_token = TIMEZONE('utc'::TEXT, CURRENT_TIMESTAMP),
                version = @version
            WHERE
                document_reference_types.reference_type_id = @reference_type_id
            and document_reference_types.concurrency_token = @validate_concurrency_token
            RETURNING document_reference_types.reference_type_id;
            """,
            new
            {
                id = db.Id,
                reference_type_id = db.ReferenceTypeId,
                domain_id = db.DomainId,
                display_name = db.DisplayName,
                data = db.Data,
                created_by_id = db.CreatedById,
                updated_by_id = db.UpdatedById,
                created_datetime = DateTime.SpecifyKind(db.CreatedDateTime, DateTimeKind.Utc),
                updated_datetime = DateTime.SpecifyKind(db.UpdatedDateTime, DateTimeKind.Utc),
                validate_concurrency_token = DateTime.SpecifyKind(db.ConcurrencyToken, DateTimeKind.Utc),
                is_deleted = false,
                version = db.Version
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Get(DomainId? domainId, int referenceTypeId, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                t.id,
                t.reference_type_id,
                t.domain_id,
                t.display_name,
                t.data,
                t.created_by_id,
                t.updated_by_id,
                t.created_datetime,
                t.updated_datetime,
                t.is_deleted,
                t.version,
                t.concurrency_token
            FROM document_reference_types t
            WHERE (@domain_id IS NULL OR t.domain_id = @domain_id)
                AND t.is_deleted = FALSE
              AND t.reference_type_id = @reference_type_id;
            """,
            new
            {
                reference_type_id = referenceTypeId,
                domain_id = domainId?.Value
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetAll(DomainId? domainId, GetAllDocumentReferenceTypesQueryParamsDb queryParams, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                t.id,
                t.domain_id,
                t.reference_type_id,
                t.display_name,
                t.data,
                t.created_by_id,
                t.updated_by_id,
                t.created_datetime,
                t.updated_datetime,
                t.is_deleted,
                t.version,
                t.concurrency_token
            FROM document_reference_types t
            WHERE (@domain_id IS NULL OR t.domain_id = @domain_id)
                AND t.is_deleted = FALSE
                AND (@display_name IS NULL OR t.display_name ILIKE CONCAT('%', @display_name, '%'))
            ORDER BY t.display_name
            LIMIT @limit
            OFFSET @skip;
            """,
            new
            {
                domain_id = domainId?.Value,
                display_name = queryParams.Query,
                limit = queryParams.Limit,
                skip = queryParams.Skip
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetLastReferenceTypeId(CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT MAX(t.reference_type_id)
            FROM document_reference_types t;
            """,
            cancellationToken: cancellationToken);
    }
}
