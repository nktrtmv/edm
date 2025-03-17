using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Statuses;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups;

internal static class ApprovalWorkflowGroupDbConverter
{
    internal static ApprovalWorkflowGroupDb FromDomain(ApprovalWorkflowGroup group)
    {
        var id = IdConverterTo.ToString(group.Id);

        ApprovalWorkflowApprovalGroupDb approvalGroup = ApprovalWorkflowApprovalGroupDbConverter.FromDomain(group.ApprovalGroup);

        ApprovalWorkflowAssignmentDb[] assignments = group.Assignments.Select(ApprovalWorkflowAssignmentDbConverter.FromDomain).ToArray();

        ApprovalWorkflowGroupStatusDb status = ApprovalWorkflowGroupStatusDbConverter.FromDomain(group.Status);

        var result = new ApprovalWorkflowGroupDb
        {
            Id = id,
            Name = group.Name,
            ApprovalGroup = approvalGroup,
            Assignments = { assignments },
            Status = status
        };

        return result;
    }

    internal static ApprovalWorkflowGroup ToDomain(ApprovalWorkflowGroupDb group)
    {
        Id<ApprovalWorkflowGroup> id = IdConverterFrom<ApprovalWorkflowGroup>.FromString(group.Id);

        ApprovalWorkflowApprovalGroup approvalGroup = ApprovalWorkflowApprovalGroupDbConverter.ToDomain(group.ApprovalGroup);

        ApprovalWorkflowAssignment[] assignments = group.Assignments.Select(ApprovalWorkflowAssignmentDbConverter.ToDomain).ToArray();

        ApprovalWorkflowGroupStatus status = ApprovalWorkflowGroupStatusDbConverter.ToDomain(group.Status);

        ApprovalWorkflowGroup result = ApprovalWorkflowGroupFactory.CreateFromDb(id, group.Name, approvalGroup, assignments, status);

        return result;
    }
}
