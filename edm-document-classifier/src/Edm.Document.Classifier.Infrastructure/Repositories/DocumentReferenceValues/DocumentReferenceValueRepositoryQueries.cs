using Dapper;

using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceValues.Contracts;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceValues;

internal static class DocumentReferenceValueRepositoryQueries
{
    internal static CommandDefinition Insert(DocumentReferenceValueDb db, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO document_reference_values
            (
                id,
                display_value,
                display_sub_value,
                reference_type_id,
                is_hidden,
                created_by_id,
                updated_by_id,
                created_datetime,
                updated_datetime
            )
            VALUES
            (
                @id,
                @display_value,
                @display_sub_value,
                @reference_type_id,
                @is_hidden,
                @created_by_id,
                @updated_by_id,
                @created_datetime,
                @updated_datetime
            )
            RETURNING document_reference_values.concurrency_token;
            """,
            new
            {
                id = db.Id,
                display_value = db.DisplayValue,
                display_sub_value = db.DisplaySubValue,
                reference_type_id = db.ReferenceTypeId,
                is_hidden = db.IsHidden,
                created_by_id = db.CreatedById,
                updated_by_id = db.UpdatedById,
                created_datetime = DateTime.SpecifyKind(db.CreatedDateTime, DateTimeKind.Utc),
                updated_datetime = DateTime.SpecifyKind(db.UpdatedDateTime, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Update(DocumentReferenceValueDb db, string? newId, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            UPDATE document_reference_values
            SET
                id = @new_id,
                display_value = @display_value,
                display_sub_value = @display_sub_value,
                is_hidden = @is_hidden,
                updated_by_id = @updated_by_id,
                updated_datetime = @updated_datetime,
                concurrency_token = TIMEZONE('utc'::TEXT, CURRENT_TIMESTAMP)
            WHERE
                document_reference_values.id = @id AND document_reference_values.reference_type_id = @reference_type_id
            and document_reference_values.concurrency_token = @validate_concurrency_token
            RETURNING document_reference_values.concurrency_token;
            """,
            new
            {
                id = db.Id,
                new_id = newId ?? db.Id,
                display_value = db.DisplayValue,
                display_sub_value = db.DisplaySubValue,
                reference_type_id = db.ReferenceTypeId,
                is_hidden = db.IsHidden,
                created_by_id = db.CreatedById,
                updated_by_id = db.UpdatedById,
                created_datetime = DateTime.SpecifyKind(db.CreatedDateTime, DateTimeKind.Utc),
                updated_datetime = DateTime.SpecifyKind(db.UpdatedDateTime, DateTimeKind.Utc),
                validate_concurrency_token = DateTime.SpecifyKind(db.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition BulkUpsert(DocumentReferenceValueDb[] db, CancellationToken cancellationToken)
    {
        const string queryTemplate = @"
                INSERT INTO document_reference_values
                (
                    id,
                    display_value,
                    display_sub_value,
                    reference_type_id,
                    is_hidden,
                    created_by_id,
                    updated_by_id,
                    created_datetime,
                    updated_datetime,
                    concurrency_token
                )
                VALUES
                (
                    UNNEST(@id),
                    UNNEST(@display_value),
                    UNNEST(@display_sub_value),
                    UNNEST(@reference_type_id),
                    UNNEST(@is_hidden),
                    UNNEST(@created_by_id),
                    UNNEST(@updated_by_id),
                    UNNEST(@created_datetime),
                    UNNEST(@updated_datetime),
                    UNNEST(@concurrency_token)
                )
                ON CONFLICT (reference_type_id, id) DO UPDATE
                SET
                    display_value = excluded.display_value,
                    display_sub_value = excluded.display_sub_value,
                    is_hidden = excluded.is_hidden,
                    created_by_id = excluded.created_by_id,
                    updated_by_id = excluded.updated_by_id,
                    created_datetime = excluded.created_datetime,
                    updated_datetime = excluded.updated_datetime,
                    concurrency_token = CASE WHEN CAST(excluded.concurrency_token as TIMESTAMP) IS NOT NULL THEN excluded.concurrency_token ELSE TIMEZONE('utc'::TEXT, CURRENT_TIMESTAMP) END
                WHERE
                    document_reference_values.id = excluded.id
                    AND document_reference_values.reference_type_id = excluded.reference_type_id
                    AND document_reference_values.concurrency_token = excluded.concurrency_token
                RETURNING document_reference_values.concurrency_token;
                ";

        var query = new CommandDefinition(
            queryTemplate,
            new
            {
                id = db.Select(o => o.Id).ToArray(),
                display_value = db.Select(o => o.DisplayValue).ToArray(),
                display_sub_value = db.Select(o => o.DisplaySubValue).ToArray(),
                reference_type_id = db.Select(o => o.ReferenceTypeId).ToArray(),
                is_hidden = db.Select(o => o.IsHidden).ToArray(),
                created_by_id = db.Select(o => o.CreatedById).ToArray(),
                updated_by_id = db.Select(o => o.UpdatedById).ToArray(),
                created_datetime = db.Select(o => o.CreatedDateTime).ToArray(),
                updated_datetime = db.Select(o => o.UpdatedDateTime).ToArray(),
                concurrency_token = db.Select(o => o.ConcurrencyToken).ToArray()
            },
            cancellationToken: cancellationToken);

        return query;
    }

    internal static CommandDefinition Get(int referenceTypeId, string id, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                t.id,
                t.display_value,
                t.display_sub_value,
                t.reference_type_id,
                t.is_hidden,
                t.created_by_id,
                t.updated_by_id,
                t.created_datetime,
                t.updated_datetime,
                t.concurrency_token
            FROM document_reference_values t
            WHERE t.reference_type_id = @reference_type_id
              AND t.id = @id;
            """,
            new
            {
                id,
                reference_type_id = referenceTypeId
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetByIds(int referenceTypeId, string[] ids, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                t.id,
                t.display_value,
                t.display_sub_value,
                t.reference_type_id,
                t.is_hidden,
                t.created_by_id,
                t.updated_by_id,
                t.created_datetime,
                t.updated_datetime,
                t.concurrency_token
            FROM document_reference_values t
            WHERE t.reference_type_id = @reference_type_id
              AND t.id = ANY(@ids);
            """,
            new
            {
                ids,
                reference_type_id = referenceTypeId
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetAll(
        int referenceTypeId,
        GetAllDocumentReferenceTypesQueryParamsDb queryParams,
        bool showHidden,
        CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                t.id,
                t.display_value,
                t.display_sub_value,
                t.reference_type_id,
                t.is_hidden,
                t.created_by_id,
                t.updated_by_id,
                t.created_datetime,
                t.updated_datetime,
                t.concurrency_token
            FROM document_reference_values t
            WHERE t.reference_type_id = @reference_type_id
                AND (@display_value IS NULL OR t.display_value ILIKE CONCAT('%', @display_value, '%'))
                AND (@ids IS NULL OR cardinality(@ids) = 0 OR t.id = ANY(@ids))
                AND (@show_hidden = true OR t.is_hidden = false)
            ORDER BY t.display_value
            LIMIT @limit
            OFFSET @skip;
            """,
            new
            {
                reference_type_id = referenceTypeId,
                display_value = string.IsNullOrWhiteSpace(queryParams.Query) ? null : queryParams.Query,
                limit = queryParams.Limit,
                skip = queryParams.Skip,
                ids = queryParams.Ids,
                show_hidden = showHidden
            },
            cancellationToken: cancellationToken);
    }
}
