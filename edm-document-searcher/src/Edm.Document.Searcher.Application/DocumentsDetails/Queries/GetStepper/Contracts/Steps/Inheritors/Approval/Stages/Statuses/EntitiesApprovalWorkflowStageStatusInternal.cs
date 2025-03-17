namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Statuses;

public enum EntitiesApprovalWorkflowStageStatusInternal
{
    None = 0,
    NotStarted = 1,
    InProgress = 2,
    Approved = 3,
    Rejected = 4,
    ApprovedWithRemark = 5,
    ReturnedToRework = 6
}
