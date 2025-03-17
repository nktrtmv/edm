namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted.Statuses;

public enum WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal
{
    None = 0,
    Signed = 1,
    Cancelled = 2,
    ReturnedToRework = 3,
    Withdrawn = 4
}
