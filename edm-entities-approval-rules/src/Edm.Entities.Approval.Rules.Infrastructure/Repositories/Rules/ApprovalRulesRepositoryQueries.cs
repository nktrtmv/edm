using Dapper;

using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules;

internal static class ApprovalRulesRepositoryQueries
{
    internal static CommandDefinition Upsert(ApprovalRuleDb rule, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO approval_rules
            (
                domain_id,
                entity_type_id,
                entity_type_updated_date,
                original_version,
                version,
                is_active,
                display_name,
                data,
                created_by,
                updated_by,
                created_at,
                updated_at
            )
            VALUES
            (
                @domain_id,
                @entity_type_id,
                @entity_type_updated_date,
                @original_version,
                @version,
                @is_active,
                @display_name,
                @data,
                @created_by,
                @updated_by,
                @created_at,
                @updated_at
            )
            ON CONFLICT ON CONSTRAINT approval_rules_key DO UPDATE
            SET
                is_active = excluded.is_active,
                display_name = excluded.display_name,
                data = excluded.data,
                updated_by = excluded.updated_by,
                updated_at = excluded.updated_at,
                concurrency_token = timezone('utc'::text, CURRENT_TIMESTAMP)
            WHERE
                approval_rules.domain_id = @domain_id
                AND approval_rules.entity_type_id = @entity_type_id
                AND approval_rules.entity_type_updated_date = @entity_type_updated_date
                AND approval_rules.version = @version
                AND approval_rules.concurrency_token = @concurrency_token
            RETURNING approval_rules.concurrency_token;
            """,
            new
            {
                domain_id = rule.DomainId,
                entity_type_id = rule.EntityTypeId,
                entity_type_updated_date = rule.EntityTypeUpdatedDate,
                original_version = rule.OriginalVersion,
                version = rule.Version,
                is_active = rule.IsActive,
                display_name = rule.DisplayName,
                data = rule.Data,
                created_by = rule.CreatedBy,
                updated_by = rule.UpdatedBy,
                created_at = rule.CreatedAt,
                updated_at = rule.UpdatedAt,
                concurrency_token = DateTime.SpecifyKind(rule.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetAll(string domainId, bool isActiveRequired, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                r.domain_id,
                r.entity_type_id,
                r.entity_type_updated_date,
                r.original_version,
                r.version,
                r.is_active,
                r.display_name,
                r.data,
                r.created_by,
                r.updated_by,
                r.created_at,
                r.updated_at,
                r.concurrency_token,
                r.is_deleted
            FROM approval_rules r
            WHERE
                r.domain_id = @domain_id
                AND is_active = @is_active
                AND r.is_deleted = FALSE;
            """,
            new
            {
                domain_id = domainId,
                is_active = isActiveRequired
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetAllLatest(string domainId, string? search, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                r.domain_id,
                r.entity_type_id,
                r.entity_type_updated_date,
                r.original_version,
                r.version,
                r.is_active,
                r.display_name,
                r.data,
                r.created_by,
                r.updated_by,
                r.created_at,
                r.updated_at,
                r.concurrency_token,
                r.is_deleted
            FROM approval_rules r
            WHERE
                r.domain_id = @domain_id
                AND (@search IS NULL OR r.display_name ILIKE '%' || @search || '%')
                AND r.entity_type_updated_date = (
                    SELECT MAX(sub.entity_type_updated_date)
                    FROM approval_rules sub
                    WHERE sub.domain_id = r.domain_id
                    AND sub.entity_type_id = r.entity_type_id
                )
                AND (
                    r.is_active = TRUE
                    OR (r.is_active = FALSE AND r.version = (
                        SELECT MAX(sub.version)
                        FROM approval_rules sub
                        WHERE sub.domain_id = r.domain_id
                        AND sub.entity_type_id = r.entity_type_id
                        AND sub.entity_type_updated_date = r.entity_type_updated_date
                        AND NOT EXISTS (
                            SELECT 1
                            FROM approval_rules sub_sub
                            WHERE sub_sub.domain_id = r.domain_id
                            AND sub_sub.entity_type_id = r.entity_type_id
                            AND sub_sub.entity_type_updated_date = r.entity_type_updated_date
                            AND sub_sub.is_active = TRUE
                        )
                    ))
                )
                AND r.is_deleted = FALSE;
            """,
            new
            {
                domain_id = domainId,
                search
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetAllVersions(EntityTypeKeyDb key, bool isDeletedIncluded, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                r.domain_id,
                r.entity_type_id,
                r.entity_type_updated_date,
                r.version
            FROM approval_rules r
            WHERE r.domain_id = @domain_id
            AND r.entity_type_id = @entity_type_id
            AND r.entity_type_updated_date = @entity_type_updated_date
            AND (@is_deleted_included = TRUE OR r.is_deleted = FALSE);
            """,
            new
            {
                domain_id = key.DomainId,
                entity_type_id = key.EntityTypeId,
                entity_type_updated_date = key.EntityTypeUpdatedDate,
                is_deleted_included = isDeletedIncluded
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetActualVersions(EntityTypeKeyDb key, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                r.domain_id,
                r.entity_type_id,
                r.entity_type_updated_date,
                r.original_version,
                r.version,
                r.is_active,
                r.display_name,
                r.data,
                r.created_by,
                r.updated_by,
                r.created_at,
                r.updated_at,
                r.concurrency_token,
                r.is_deleted
            FROM approval_rules r
            WHERE
                r.domain_id = @domain_id
                AND r.entity_type_id = @entity_type_id
                AND r.entity_type_updated_date = (
                    SELECT MAX(sub.entity_type_updated_date)
                    FROM approval_rules sub
                    WHERE
                        sub.domain_id = @domain_id
                        AND sub.entity_type_id = @entity_type_id
                        AND sub.entity_type_updated_date <= @entity_type_updated_date
                )
                AND r.is_deleted = FALSE
            ORDER BY r.version;
            """,
            new
            {
                domain_id = key.DomainId,
                entity_type_id = key.EntityTypeId,
                entity_type_updated_date = key.EntityTypeUpdatedDate
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Get(ApprovalRuleKeyDb key, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                r.domain_id,
                r.entity_type_id,
                r.entity_type_updated_date,
                r.original_version,
                r.version,
                r.is_active,
                r.display_name,
                r.data,
                r.created_by,
                r.updated_by,
                r.created_at,
                r.updated_at,
                r.concurrency_token,
                r.is_deleted
            FROM approval_rules r
            WHERE
                r.domain_id = @domain_id
                AND r.entity_type_id = @entity_type_id
                AND r.entity_type_updated_date = @entity_type_updated_date
                AND r.version = @version;
            """,
            new
            {
                domain_id = key.DomainId,
                entity_type_id = key.EntityTypeId,
                entity_type_updated_date = key.EntityTypeUpdatedDate,
                version = key.Version
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetLastVersion(EntityTypeKeyDb key, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                r.domain_id,
                r.entity_type_id,
                r.entity_type_updated_date,
                r.original_version,
                r.version,
                r.is_active,
                r.display_name,
                r.data,
                r.created_by,
                r.updated_by,
                r.created_at,
                r.updated_at,
                r.concurrency_token,
                r.is_deleted
            FROM approval_rules r
            WHERE
                r.domain_id = @domain_id
                AND r.entity_type_updated_date = @entity_type_updated_date
                AND r.entity_type_id = @entity_type_id
                AND r.version = (
                        SELECT MAX(sub.version)
                        FROM approval_rules sub
                        WHERE sub.domain_id = @domain_id
                        AND sub.entity_type_id = @entity_type_id
                        AND sub.entity_type_updated_date = @entity_type_updated_date
                );
            """,
            new
            {
                entity_type_updated_date = key.EntityTypeUpdatedDate,
                domain_id = key.DomainId,
                entity_type_id = key.EntityTypeId
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition GetActive(EntityTypeKeyDb key, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                r.domain_id,
                r.entity_type_id,
                r.entity_type_updated_date,
                r.original_version,
                r.version,
                r.is_active,
                r.display_name,
                r.data,
                r.created_by,
                r.updated_by,
                r.created_at,
                r.updated_at,
                r.concurrency_token,
                r.is_deleted
            FROM approval_rules r
            WHERE r.domain_id = @domain_id
            AND r.entity_type_id = @entity_type_id
            AND r.entity_type_updated_date = @entity_type_updated_date
            AND r.is_active = TRUE;
            """,
            new
            {
                domain_id = key.DomainId,
                entity_type_id = key.EntityTypeId,
                entity_type_updated_date = key.EntityTypeUpdatedDate
            },
            cancellationToken: cancellationToken);
    }

    internal static CommandDefinition Delete(EntityTypeKeyDb key, ApprovalRuleAuditDb audit, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            UPDATE approval_rules r
                SET is_deleted = TRUE,
                    updated_by = @updated_by,
                    updated_at = @updated_at
            WHERE r.domain_id = @domain_id
            AND r.entity_type_id = @entity_type_id
            AND is_deleted = FALSE
            """,
            new
            {
                domain_id = key.DomainId,
                entity_type_id = key.EntityTypeId,
                updated_by = audit.Brief.UpdatedBy,
                updated_at = DateTime.SpecifyKind(audit.Brief.UpdatedAt, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);
    }
}
