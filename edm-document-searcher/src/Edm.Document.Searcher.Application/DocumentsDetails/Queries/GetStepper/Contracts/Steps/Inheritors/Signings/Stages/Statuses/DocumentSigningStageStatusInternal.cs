namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Statuses;

public enum DocumentSigningStageStatusInternal
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
