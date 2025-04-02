namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts.Statuses;

public enum DocumentSigningStatusInternal
{
    None = 0,
    Signed = 1,
    Cancelled = 2,
    ToPreparation = 3,
    ReturnedToRework = 4
}
