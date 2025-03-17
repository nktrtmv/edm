using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups;

internal static class ApprovalWorkflowGroupInternalConverter
{
    public static ApprovalWorkflowGroupInternal FromDomain(ApprovalWorkflowGroup group)
    {
        Id<ApprovalWorkflowGroupInternal> id = IdConverterFrom<ApprovalWorkflowGroupInternal>.From(group.Id);

        ApprovalWorkflowAssignmentInternal[] assignments =
            group.Assignments.Select(ApprovalWorkflowAssignmentInternalConverter.FromDomain).ToArray();

        ApprovalWorkflowGroupStatusInternal status =
            ApprovalWorkflowGroupStatusInternalConverter.FromDomain(group.Status);

        var result = new ApprovalWorkflowGroupInternal(id, group.Name, assignments, status);

        return result;
    }
}
