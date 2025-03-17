using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Info;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.Info;

internal static class ApprovalInfoDtoConverter
{
    internal static ApprovalInfoInternal ToInternal(ApprovalInfoDto info)
    {
        var result = new ApprovalInfoInternal(info.Title, info.Description);

        return result;
    }
}
