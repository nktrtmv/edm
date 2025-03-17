using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Info;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Info;

internal static class ApprovalWorkflowInfoInternalConverter
{
    internal static ApprovalWorkflowInfo ToDomain(ApprovalInfoInternal info)
    {
        var result = new ApprovalWorkflowInfo(info.Title, info.Description);

        return result;
    }
}
