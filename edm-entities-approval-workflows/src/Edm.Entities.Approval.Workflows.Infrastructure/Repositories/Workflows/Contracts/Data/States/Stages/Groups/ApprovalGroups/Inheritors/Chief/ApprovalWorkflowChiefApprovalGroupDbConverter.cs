using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Chief;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Chief;

internal static class ApprovalWorkflowChiefApprovalGroupDbConverter
{
    internal static ApprovalWorkflowApprovalGroupDb FromDomain(ApprovalWorkflowChiefApprovalGroup group)
    {
        var currentUserId = IdConverterTo.ToString(group.CurrentUserId);

        var asChief = new ApprovalWorkflowChiefApprovalGroupDb
        {
            CurrentUserId = currentUserId
        };

        var result = new ApprovalWorkflowApprovalGroupDb
        {
            AsChief = asChief
        };

        return result;
    }

    internal static ApprovalWorkflowChiefApprovalGroup ToDomain(ApprovalWorkflowChiefApprovalGroupDb group)
    {
        Id<Employee> currentUserId = IdConverterFrom<Employee>.FromString(group.CurrentUserId);

        var result = new ApprovalWorkflowChiefApprovalGroup(currentUserId);

        return result;
    }
}
