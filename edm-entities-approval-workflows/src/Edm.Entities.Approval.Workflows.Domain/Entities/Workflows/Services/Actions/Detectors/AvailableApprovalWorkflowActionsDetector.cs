using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Executors;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Owners;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Owners.Detectors;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors;

public static class AvailableApprovalWorkflowActionsDetector
{
    private static readonly List<ApprovalWorkflowActionKind> AdminActions =
    [
        ApprovalWorkflowActionKind.Reject,
        ApprovalWorkflowActionKind.Delegate
    ];

    public static HashSet<ApprovalWorkflowActionKind> Detect(ApprovalWorkflowActionContext context)
    {
        bool currentUserIsOwner = ApprovalWorkflowOwnersDetector.Detect(context);

        HashSet<ApprovalWorkflowActionKind> result = currentUserIsOwner switch
        {
            true => AvailableOwnerApprovalWorkflowActionsDetector.Detect(context).ToHashSet(),
            false => AvailableExecutorApprovalWorkflowActionsDetector.Detect(context).ToHashSet()
        };

        DetectAdminActions(context.CurrentUserIsAdmin, result);

        return result;
    }

    private static void DetectAdminActions(bool currentUserIsAdmin, HashSet<ApprovalWorkflowActionKind> actions)
    {
        if (currentUserIsAdmin)
        {
            actions.UnionWith(AdminActions);
        }
    }
}
