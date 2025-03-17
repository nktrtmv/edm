using Dapper;

using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.QueryParams;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates;

internal static class DocumentsTemplatesRepositoryQueries
{
    internal static CommandDefinition Upsert(DocumentTemplateDb template, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
INSERT INTO document_templates
(
    id,
    domain_id,
    system_name,
    name,
    data,
    created_by_id,
    updated_by_id,
    created_datetime,
    updated_datetime
)
VALUES
(
    @domain_id,
    @id,
    @name,
    @system_name,
    @data,
    @created_by_id,
    @updated_by_id,
    @created_datetime,
    @updated_datetime
)
ON CONFLICT (id) DO UPDATE
SET
    name = excluded.name,
    system_name = excluded.system_name,
    data = excluded.data,
    updated_by_id = excluded.updated_by_id,
    updated_datetime = excluded.updated_datetime,
    concurrency_token = timezone('utc'::text, CURRENT_TIMESTAMP)
WHERE
    document_templates.id = @id
    AND document_templates.concurrency_token = @concurrency_token
RETURNING document_templates.id;
",
            new
            {
                domain_id = template.DomainId,
                id = template.Id,
                name = template.Name,
                system_name = template.SystemName,
                data = template.Data,
                created_by_id = template.CreatedById,
                updated_by_id = template.UpdatedById,
                created_datetime = DateTime.SpecifyKind(template.CreatedDateTime, DateTimeKind.Utc),
                updated_datetime = DateTime.SpecifyKind(template.UpdatedDateTime, DateTimeKind.Utc),
                concurrency_token = DateTime.SpecifyKind(template.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Delete(DocumentTemplateDb template, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
UPDATE document_templates
SET is_deleted = TRUE,
    updated_by_id = @updated_by_id,
    updated_datetime = @updated_datetime
WHERE domain_id = @domain_id AND id = @id;
",
            new
            {
                domain_id = template.DomainId,
                template.Id,
                updated_by_id = template.UpdatedById,
                updated_datetime = DateTime.SpecifyKind(template.UpdatedDateTime, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetById(DomainId domainId, string id, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    t.id,
    t.domain_id,
    t.system_name,
    t.name,
    t.data,
    t.created_by_id,
    t.updated_by_id,
    t.created_datetime,
    t.updated_datetime,
    t.is_deleted,
    t.concurrency_token
FROM document_templates t
WHERE t.domain_id = @domain_id AND t.id = @id;
",
            new
            {
                id,
                domain_id = domainId.Value
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetBySystemName(DomainId domainId, SystemName systemName, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    t.id,
    t.domain_id,
    t.system_name,
    t.name,
    t.data,
    t.created_by_id,
    t.updated_by_id,
    t.created_datetime,
    t.updated_datetime,
    t.is_deleted,
    t.concurrency_token
FROM document_templates t
WHERE t.domain_id = @domain_id AND t.system_name = @system_name;
",
            new
            {
                system_name = systemName.Value,
                domain_id = domainId.Value
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Search(DomainId domainId, GetAllDocumentsTemplatesQueryParamsDb queryParams, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    t.id,
    t.domain_id,
    t.system_name,
    t.name,
    t.data,
    t.created_by_id,
    t.updated_by_id,
    t.created_datetime,
    t.updated_datetime,
    t.is_deleted,
    t.concurrency_token
FROM document_templates t
WHERE t.domain_id = @domain_id
    AND t.is_deleted = FALSE
    AND (@name IS NULL OR t.name ILIKE CONCAT('%', @name, '%'))
ORDER BY t.name
LIMIT @limit
OFFSET @skip;
",
            new
            {
                domain_id = domainId.Value,
                name = queryParams.Query,
                limit = queryParams.Limit,
                skip = queryParams.Skip
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetAllIds(DomainId domainId, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    t.id
FROM document_templates t
WHERE t.domain_id=@domain_id AND t.is_deleted = FALSE;
",
            new
            {
                domain_id = domainId.Value
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetByIds(DomainId domainId, string[] templateIds, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    t.id,
    t.domain_id,
    t.system_name,
    t.name,
    t.data,
    t.created_by_id,
    t.updated_by_id,
    t.created_datetime,
    t.updated_datetime,
    t.is_deleted,
    t.concurrency_token
FROM document_templates t
WHERE t.domain_id = @domain_id
    AND t.is_deleted = FALSE
    AND t.id = ANY(@templates_ids)
ORDER BY t.name;
",
            new
            {
                templates_ids = templateIds,
                domain_id = domainId.Value
            },
            cancellationToken: cancellationToken);
    }
}
