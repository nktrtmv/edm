using Dapper;

using Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications.Contracts;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications;

internal static class DocumentClassificationRepositoryQueries
{
    public static CommandDefinition Upsert(DocumentClassificationDb db, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO document_classifiers
            (
                document_template_id,
                data,
                data_for_search
            )
            VALUES
            (
                @documentTemplateId,
                @data,
                @data_for_search::json
            )
            ON CONFLICT (document_template_id) do update
            SET
                data = EXCLUDED.data,
                data_for_search = EXCLUDED.data_for_search::json,
                updated_date = TIMEZONE('utc'::text, CURRENT_TIMESTAMP)
            WHERE
                document_classifiers.document_template_id = @documentTemplateId
                and document_classifiers.updated_date = @updated_date
            RETURNING document_classifiers.document_template_id;
            """,
            new
            {
                documentTemplateId = db.DocumentTemplateId,
                data = db.Data,
                data_for_search = db.DataForSearch,
                updated_date = DateTime.SpecifyKind(db.UpdatedDate, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Get(string? documentTemplateId, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                d.document_template_id,
                d.data,
                d.created_date,
                d.updated_date,
                d.data_for_search
            FROM document_classifiers d
            WHERE (@documentTemplateId is null or d.document_template_id = @documentTemplateId);
            """,
            new
            {
                documentTemplateId
            },
            cancellationToken: cancellationToken);
    }
}
