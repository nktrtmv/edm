using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Types;

internal static class ApprovalWorkflowStageTypeDbConverter
{
    internal static ApprovalWorkflowStageTypeDb FromDomain(ApprovalWorkflowStageType type)
    {
        ApprovalWorkflowStageTypeDb result = type switch
        {
            ApprovalWorkflowStageType.ParallelAny => ApprovalWorkflowStageTypeDb.ParallelAny,
            ApprovalWorkflowStageType.ParallelAll => ApprovalWorkflowStageTypeDb.ParallelAll,
            ApprovalWorkflowStageType.Sequential => ApprovalWorkflowStageTypeDb.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static ApprovalWorkflowStageType ToDomain(ApprovalWorkflowStageTypeDb type)
    {
        ApprovalWorkflowStageType result = type switch
        {
            ApprovalWorkflowStageTypeDb.ParallelAny => ApprovalWorkflowStageType.ParallelAny,
            ApprovalWorkflowStageTypeDb.ParallelAll => ApprovalWorkflowStageType.ParallelAll,
            ApprovalWorkflowStageTypeDb.Sequential => ApprovalWorkflowStageType.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
