using Dapper;

using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows;

internal static class SigningWorkflowsRepositoryQueries
{
    internal static CommandDefinition Upsert(SigningWorkflowDb workflow, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
INSERT INTO signing_workflows
(
    id,
    entity_id,
    domain_id,
    status,
    status_changed_at,
    data
)
VALUES
(
    @id,
    @entity_id,
    @domain_id,
    @status,
    @status_changed_at,
    @data
)
ON CONFLICT (id) DO UPDATE
SET
    status = EXCLUDED.status,
    status_changed_at = EXCLUDED.status_changed_at,
    data = EXCLUDED.data,
    concurrency_token = TIMEZONE('utc'::text, CURRENT_TIMESTAMP)
WHERE
    signing_workflows.id = @id
    AND signing_workflows.concurrency_token = @concurrency_token
RETURNING signing_workflows.concurrency_token;
",
            new
            {
                id = workflow.Id,
                entity_id = workflow.EntityId,
                domain_id = workflow.DomainId,
                status = workflow.Status,
                status_changed_at = DateTime.SpecifyKind(workflow.StatusChangedAt, DateTimeKind.Utc),
                data = workflow.Data,
                concurrency_token = workflow.ConcurrencyToken
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Get(string id, CancellationToken cancellationToken)
    {
        return new CommandDefinition(
            @"
SELECT
    w.id,
    w.entity_id,
    w.domain_id,
    w.status,
    w.status_changed_at,
    w.data,
    w.concurrency_token
FROM signing_workflows w
WHERE w.id = @id;
",
            new
            {
                id
            },
            cancellationToken: cancellationToken);
    }
}
