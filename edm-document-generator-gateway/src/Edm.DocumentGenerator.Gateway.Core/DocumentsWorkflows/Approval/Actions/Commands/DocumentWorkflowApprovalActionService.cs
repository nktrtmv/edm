using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands;

public abstract class DocumentWorkflowApprovalActionService
{
    protected DocumentWorkflowApprovalActionService(IEntitiesApprovalWorkflowsActionsClient approvalActions)
    {
        ApprovalActions = approvalActions;
    }

    protected IEntitiesApprovalWorkflowsActionsClient ApprovalActions { get; }
}
