using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Foreign.Arguments;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Foreign;

internal static class ApprovalWorkflowForeignApprovalGroupDbConverter
{
    internal static ApprovalWorkflowApprovalGroupDb FromDomain(ApprovalWorkflowForeignApprovalGroup group)
    {
        var groupId = IdConverterTo.ToString(group.GroupId);

        ApprovalWorkflowForeignApprovalGroupArgumentDb[] arguments =
            group.Arguments.Select(ApprovalWorkflowForeignApprovalGroupArgumentDbFromDomainConverter.FromDomain).ToArray();

        var asForeign = new ApprovalWorkflowForeignApprovalGroupDb
        {
            GroupId = groupId,
            Arguments = { arguments }
        };

        var result = new ApprovalWorkflowApprovalGroupDb
        {
            AsForeign = asForeign
        };

        return result;
    }

    internal static ApprovalWorkflowForeignApprovalGroup ToDomain(ApprovalWorkflowForeignApprovalGroupDb group)
    {
        Id<ApprovalWorkflowForeignApprovalGroup> groupId =
            IdConverterFrom<ApprovalWorkflowForeignApprovalGroup>.FromString(group.GroupId);

        ForeignApprovalGroupArgument[] arguments =
            group.Arguments.Select(ApprovalWorkflowForeignApprovalGroupArgumentDbToDomainConverter.ToDomain).ToArray();

        var result = new ApprovalWorkflowForeignApprovalGroup(groupId, arguments);

        return result;
    }
}
