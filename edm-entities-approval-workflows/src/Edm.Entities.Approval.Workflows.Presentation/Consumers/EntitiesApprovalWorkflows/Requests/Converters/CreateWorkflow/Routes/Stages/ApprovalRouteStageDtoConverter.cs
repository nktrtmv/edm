using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Types;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Types;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages;

internal static class ApprovalRouteStageDtoConverter
{
    internal static ApprovalRouteStageInternal ToInternal(ApprovalRouteStageDto stage)
    {
        Id<ApprovalRouteStageInternal> id =
            NullableConverter.Convert(stage.Id, IdConverterFrom<ApprovalRouteStageInternal>.FromString)
            ?? Id<ApprovalRouteStageInternal>.CreateNew();

        ApprovalRouteStageTypeInternal type =
            ApprovalRouteStageTypeDtoConverter.ToInternal(stage.Type);

        ApprovalGroupInternal[] approvalGroups =
            stage.Groups.Select(ApprovalRouteGroupDtoConverter.ToInternal).ToArray();

        var result = new ApprovalRouteStageInternal(id, type, stage.Name, approvalGroups);

        return result;
    }
}
