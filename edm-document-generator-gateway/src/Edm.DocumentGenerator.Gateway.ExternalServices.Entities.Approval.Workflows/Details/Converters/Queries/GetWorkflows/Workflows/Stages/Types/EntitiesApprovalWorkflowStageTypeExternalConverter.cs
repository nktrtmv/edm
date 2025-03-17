using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;

internal static class EntitiesApprovalWorkflowStageTypeExternalConverter
{
    internal static EntitiesApprovalWorkflowStageTypeExternal FromDto(EntitiesApprovalWorkflowStageTypeDto type)
    {
        var result = type switch
        {
            EntitiesApprovalWorkflowStageTypeDto.ParallelAny => EntitiesApprovalWorkflowStageTypeExternal.ParallelAny,
            EntitiesApprovalWorkflowStageTypeDto.ParallelAll => EntitiesApprovalWorkflowStageTypeExternal.ParallelAll,
            EntitiesApprovalWorkflowStageTypeDto.Sequential => EntitiesApprovalWorkflowStageTypeExternal.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
