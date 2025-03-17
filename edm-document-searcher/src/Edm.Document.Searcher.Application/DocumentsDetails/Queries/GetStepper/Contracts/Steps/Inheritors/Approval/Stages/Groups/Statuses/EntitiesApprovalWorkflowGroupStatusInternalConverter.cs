using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups.
    Statuses;

internal static class EntitiesApprovalWorkflowGroupStatusInternalConverter
{
    internal static EntitiesApprovalWorkflowGroupStatusInternal FromExternal(EntitiesApprovalWorkflowGroupStatusExternal status)
    {
        EntitiesApprovalWorkflowGroupStatusInternal result = status switch
        {
            EntitiesApprovalWorkflowGroupStatusExternal.NotStarted => EntitiesApprovalWorkflowGroupStatusInternal.NotStarted,
            EntitiesApprovalWorkflowGroupStatusExternal.InProgress => EntitiesApprovalWorkflowGroupStatusInternal.InProgress,
            EntitiesApprovalWorkflowGroupStatusExternal.Completed => EntitiesApprovalWorkflowGroupStatusInternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
