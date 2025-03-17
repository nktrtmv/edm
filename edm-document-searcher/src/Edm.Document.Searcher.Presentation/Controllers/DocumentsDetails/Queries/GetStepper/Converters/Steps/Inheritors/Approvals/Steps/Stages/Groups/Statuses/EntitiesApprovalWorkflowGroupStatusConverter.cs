using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups.Statuses;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Statuses;

internal static class EntitiesApprovalWorkflowGroupStatusConverter
{
    internal static EntitiesApprovalWorkflowGroupStatusDto FromInternal(
        EntitiesApprovalWorkflowGroupStatusInternal status)
    {
        return status switch
        {
            EntitiesApprovalWorkflowGroupStatusInternal.NotStarted => EntitiesApprovalWorkflowGroupStatusDto.NotStarted,
            EntitiesApprovalWorkflowGroupStatusInternal.InProgress => EntitiesApprovalWorkflowGroupStatusDto.InProgress,
            EntitiesApprovalWorkflowGroupStatusInternal.Completed => EntitiesApprovalWorkflowGroupStatusDto.Completed,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
