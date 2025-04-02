using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Custom;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Custom;

internal static class ApprovalWorkflowCustomApprovalGroupDbConverter
{
    internal static ApprovalWorkflowApprovalGroupDb FromDomain(ApprovalWorkflowCustomApprovalGroup group)
    {
        var asCustom = new ApprovalWorkflowCustomApprovalGroupDb();

        var result = new ApprovalWorkflowApprovalGroupDb
        {
            AsCustom = asCustom
        };

        return result;
    }

    internal static ApprovalWorkflowCustomApprovalGroup ToDomain(ApprovalWorkflowCustomApprovalGroupDb group)
    {
        var result = new ApprovalWorkflowCustomApprovalGroup();

        return result;
    }
}
