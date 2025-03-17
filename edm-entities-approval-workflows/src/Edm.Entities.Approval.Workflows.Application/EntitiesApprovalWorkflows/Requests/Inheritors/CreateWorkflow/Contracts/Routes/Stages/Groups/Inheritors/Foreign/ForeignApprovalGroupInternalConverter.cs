using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign.Arguments;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign;

internal static class ForeignApprovalGroupInternalConverter
{
    internal static ApprovalWorkflowForeignApprovalGroup ToDomain(ForeignApprovalGroupInternal group)
    {
        Id<ApprovalWorkflowForeignApprovalGroup> groupId =
            IdConverterFrom<ApprovalWorkflowForeignApprovalGroup>.From(group.GroupId);

        ForeignApprovalGroupArgument[] arguments =
            group.Arguments.Select(ForeignApprovalGroupArgumentInternalToDomainConverter.ToDomain).ToArray();

        var result = new ApprovalWorkflowForeignApprovalGroup(groupId, arguments);

        return result;
    }
}
