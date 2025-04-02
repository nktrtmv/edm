namespace Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;

public enum SigningWorkflowStageStatusExternal
{
    None = 0,
    NotStarted = 1,
    InProgress = 2,
    Completed = 3,
    Signed = 4,
    Rejected = 5,
    ReturnedToRework = 6,
    Withdrawn = 7,
    Cancelled = 8,
    Error = 9,
    Revocation = 10,
    Revoked = 11
}
