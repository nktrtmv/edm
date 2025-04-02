using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Types;

internal static class ApprovalWorkflowStageTypeInternalConverter
{
    public static ApprovalWorkflowStageTypeInternal FromDomain(ApprovalWorkflowStageType type)
    {
        ApprovalWorkflowStageTypeInternal result = type switch
        {
            ApprovalWorkflowStageType.Sequential => ApprovalWorkflowStageTypeInternal.Sequential,
            ApprovalWorkflowStageType.ParallelAll => ApprovalWorkflowStageTypeInternal.ParallelAll,
            ApprovalWorkflowStageType.ParallelAny => ApprovalWorkflowStageTypeInternal.ParallelAny,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
