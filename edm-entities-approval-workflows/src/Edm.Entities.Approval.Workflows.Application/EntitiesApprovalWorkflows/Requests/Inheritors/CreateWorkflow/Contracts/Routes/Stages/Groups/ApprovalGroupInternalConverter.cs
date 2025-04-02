using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Chief;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups;

internal static class ApprovalWorkflowApprovalGroupInternalConverter
{
    internal static ApprovalWorkflowGroup ToDomain(ApprovalGroupInternal group, Id<Employee> currentUserId)
    {
        ApprovalWorkflowApprovalGroup approvalGroup = ToApprovalGroup(group, currentUserId);

        ApprovalWorkflowGroup result = ApprovalWorkflowGroupFactory.CreateNew(group.Name, approvalGroup);

        return result;
    }

    private static ApprovalWorkflowApprovalGroup ToApprovalGroup(ApprovalGroupInternal group, Id<Employee> currentUserId)
    {
        ApprovalWorkflowApprovalGroup result = group switch
        {
            ChiefApprovalGroupInternal =>
                ChiefApprovalGroupInternalConverter.ToDomain(currentUserId),

            DomesticApprovalGroupInternal g =>
                DomesticApprovalGroupInternalConverter.ToDomain(g),

            ForeignApprovalGroupInternal g =>
                ForeignApprovalGroupInternalConverter.ToDomain(g),

            _ => throw new ArgumentTypeOutOfRangeException(group)
        };

        return result;
    }
}
