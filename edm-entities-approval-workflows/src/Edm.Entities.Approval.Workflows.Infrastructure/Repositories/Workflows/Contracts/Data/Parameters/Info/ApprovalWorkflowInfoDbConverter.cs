using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Info;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.Info;

internal static class ApprovalWorkflowInfoDbConverter
{
    internal static ApprovalWorkflowInfoDb FromDomain(ApprovalWorkflowInfo info)
    {
        var result = new ApprovalWorkflowInfoDb
        {
            Title = info.Title,
            Description = info.Description
        };

        return result;
    }

    internal static ApprovalWorkflowInfo ToDomain(ApprovalWorkflowInfoDb info)
    {
        var result = new ApprovalWorkflowInfo(info.Title, info.Description);

        return result;
    }
}
