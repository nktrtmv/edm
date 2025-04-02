using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Foreign.Arguments;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Foreign;

internal static class ForeignApprovalRouteGroupDtoConverter
{
    internal static ForeignApprovalGroupInternal ToInternal(ForeignApprovalRouteGroupDto group, string name)
    {
        Id<ForeignApprovalGroupInternal> groupId =
            IdConverterFrom<ForeignApprovalGroupInternal>.FromString(group.TypeId);

        ForeignApprovalGroupArgumentInternal[] arguments =
            group.Arguments.Select(ForeignApprovalRouteGroupArgumentDtoConverter.ToInternal).ToArray();

        var result = new ForeignApprovalGroupInternal(name, groupId, arguments);

        return result;
    }
}
