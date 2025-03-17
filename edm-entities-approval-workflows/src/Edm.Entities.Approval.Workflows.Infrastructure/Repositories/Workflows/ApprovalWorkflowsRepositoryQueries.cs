using Dapper;

using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows;

internal static class ApprovalWorkflowsRepositoryQueries
{
    public static CommandDefinition Delete(DomainId domainId, HashSet<EntityId> ids, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            DELETE FROM approval_workflows WHERE entity_id=ANY(@ids) AND entity_domain_id=@domainId
            """,
            new
            {
                ids = ids.Select(x => x.Value).ToArray(),
                domainId = domainId.Value
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Upsert(ApprovalWorkflowDb workflow, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            INSERT INTO approval_workflows
            (
                id,
                entity_id,
                entity_domain_id,
                status,
                data,
                actualized_date
            )
            VALUES
            (
                @id,
                @entity_id,
                @entity_domain_id,
                @status,
                @data,
                @actualized_date
            )
            ON CONFLICT (id) do update
            SET
                entity_id = EXCLUDED.entity_id,
                entity_domain_id = EXCLUDED.entity_domain_id,
                status = EXCLUDED.status,
                data = EXCLUDED.data,
                updated_date = TIMEZONE('utc'::text, CURRENT_TIMESTAMP),
                actualized_date = EXCLUDED.actualized_date
            WHERE
                approval_workflows.id = @id
                and approval_workflows.updated_date = @updated_date
            RETURNING approval_workflows.id;
            """,
            new
            {
                id = workflow.Id,
                entity_id = workflow.EntityId,
                entity_domain_id = workflow.EntityDomainId,
                status = workflow.Status,
                data = workflow.Data,
                updated_date = workflow.UpdatedDate,
                actualized_date = workflow.ActualizedDate
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetBatch(string[] workflowIds, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                w.id,
                w.status,
                w.data,
                w.actualized_date,
                w.created_date,
                w.updated_date
            FROM approval_workflows w
            WHERE w.id = ANY(@ids);
            """,
            new
            {
                ids = workflowIds
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetIds(string entityId, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT
                w.id
            FROM approval_workflows w
            WHERE @entity_id = entity_id;
            """,
            new
            {
                entity_id = entityId
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition GetAllActive(DateTime actualizeDate, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            """
            SELECT w.id
            FROM approval_workflows w
            WHERE w.status = 'in_progress' AND (w.actualized_date IS NULL OR w.actualized_date < @actualized_date)
            ORDER BY w.updated_date DESC;
            """,
            new
            {
                actualized_date = actualizeDate
            },
            cancellationToken: cancellationToken);
    }
}
