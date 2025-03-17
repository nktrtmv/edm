using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.Statuses;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments;

public sealed class EntitiesApprovalWorkflowAssignmentBff
{
    public required string Id { get; init; }
    public required int Number { get; init; }
    public required PersonBff Executor { get; init; }
    public required EntitiesApprovalWorkflowAssignmentStatusBff Status { get; init; }
    public DateTime CreatedDate { get; init; }
    public required EntitiesApprovalWorkflowAssignmentCompletionDetailsBff? CompletionDetails { get; init; }
    public required PersonBff? Author { get; init; }
    public required bool IsFixed { get; set; }
}
