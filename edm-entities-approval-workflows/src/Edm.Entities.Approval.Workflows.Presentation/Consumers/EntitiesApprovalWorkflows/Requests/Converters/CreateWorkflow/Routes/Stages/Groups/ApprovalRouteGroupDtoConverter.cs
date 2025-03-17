using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Chief;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Domestic;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Foreign;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups;

internal static class ApprovalRouteGroupDtoConverter
{
    internal static ApprovalGroupInternal ToInternal(ApprovalRouteGroupDto group)
    {
        ApprovalGroupInternal result = group.GroupCase switch
        {
            ApprovalRouteGroupDto.GroupOneofCase.AsChief =>
                ChiefApprovalRouteGroupDtoConverter.ToInternal(group.Name),

            ApprovalRouteGroupDto.GroupOneofCase.AsDomestic =>
                DomesticApprovalRouteGroupDtoConverter.ToInternal(group.AsDomestic, group.Name),

            ApprovalRouteGroupDto.GroupOneofCase.AsForeign =>
                ForeignApprovalRouteGroupDtoConverter.ToInternal(group.AsForeign, group.Name),

            _ => throw new ArgumentTypeOutOfRangeException(group.GroupCase)
        };

        return result;
    }
}
