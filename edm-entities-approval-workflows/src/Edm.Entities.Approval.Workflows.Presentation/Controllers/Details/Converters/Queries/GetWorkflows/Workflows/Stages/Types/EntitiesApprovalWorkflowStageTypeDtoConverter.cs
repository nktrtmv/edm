using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Types;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;

internal static class EntitiesApprovalWorkflowStageTypeDtoConverter
{
    internal static EntitiesApprovalWorkflowStageTypeDto FromInternal(ApprovalWorkflowStageTypeInternal type)
    {
        EntitiesApprovalWorkflowStageTypeDto result = type switch
        {
            ApprovalWorkflowStageTypeInternal.ParallelAny => EntitiesApprovalWorkflowStageTypeDto.ParallelAny,
            ApprovalWorkflowStageTypeInternal.ParallelAll => EntitiesApprovalWorkflowStageTypeDto.ParallelAll,
            ApprovalWorkflowStageTypeInternal.Sequential => EntitiesApprovalWorkflowStageTypeDto.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
