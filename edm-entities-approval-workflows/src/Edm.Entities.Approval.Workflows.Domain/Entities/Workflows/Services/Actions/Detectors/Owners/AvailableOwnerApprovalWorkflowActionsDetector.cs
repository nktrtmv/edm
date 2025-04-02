using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.Groups;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Owners;

internal static class AvailableOwnerApprovalWorkflowActionsDetector
{
    private static readonly ApprovalWorkflowActionKind[] Actions =
    {
        ApprovalWorkflowActionKind.Delegate,
        ApprovalWorkflowActionKind.AddParticipant
    };

    private static readonly ApprovalWorkflowActionKind[] ActiveGroupsAreEmptyActions =
    {
        ApprovalWorkflowActionKind.AddParticipant
    };

    internal static ApprovalWorkflowActionKind[] Detect(ApprovalWorkflowActionContext context)
    {
        Id<Employee>[] activeExecutors = ActiveApprovalWorkflowGroupsExecutorsExtractor.Extract(context.ActiveGroups);

        ApprovalWorkflowActionKind[] result = activeExecutors.Any()
            ? Actions
            : ActiveGroupsAreEmptyActions;

        return result;
    }
}
