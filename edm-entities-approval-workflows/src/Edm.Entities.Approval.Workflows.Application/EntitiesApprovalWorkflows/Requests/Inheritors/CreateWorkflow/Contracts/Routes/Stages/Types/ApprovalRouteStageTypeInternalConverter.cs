using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Types;

internal static class ApprovalRouteStageTypeInternalConverter
{
    internal static ApprovalWorkflowStageType ToDomain(ApprovalRouteStageTypeInternal type)
    {
        ApprovalWorkflowStageType result = type switch
        {
            ApprovalRouteStageTypeInternal.ParallelAny => ApprovalWorkflowStageType.ParallelAny,
            ApprovalRouteStageTypeInternal.ParallelAll => ApprovalWorkflowStageType.ParallelAll,
            ApprovalRouteStageTypeInternal.Sequential => ApprovalWorkflowStageType.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
