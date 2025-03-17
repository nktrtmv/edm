namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Statuses;

public enum EntitiesApprovalWorkflowStageStatusBff
{
    None = 0,
    NotStarted = 1,
    InProgress = 2,
    Approved = 3,
    Rejected = 4,
    ApprovedWithRemark = 5,
    ReturnedToRework = 6
}
