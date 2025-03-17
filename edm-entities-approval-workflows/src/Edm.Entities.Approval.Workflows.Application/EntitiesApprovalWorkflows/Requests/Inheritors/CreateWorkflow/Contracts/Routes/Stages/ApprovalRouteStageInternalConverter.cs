using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Types;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages;

internal static class ApprovalRouteStageInternalConverter
{
    internal static ApprovalWorkflowStage ToDomain(ApprovalRouteStageInternal stage, Id<Employee> currentUserId)
    {
        Id<ApprovalWorkflowStage> id = IdConverterFrom<ApprovalWorkflowStage>.From(stage.Id);

        ApprovalWorkflowStageType type = ApprovalRouteStageTypeInternalConverter.ToDomain(stage.Type);

        ApprovalWorkflowGroup[] groups =
            stage.ApprovalGroups.Select(a => ApprovalWorkflowApprovalGroupInternalConverter.ToDomain(a, currentUserId)).ToArray();

        ApprovalWorkflowStage result = ApprovalWorkflowStageFactory.CreateNew(id, stage.Name, type, groups);

        return result;
    }
}
