using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Types;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Types;

internal static class ApprovalRouteStageTypeDtoConverter
{
    internal static ApprovalRouteStageTypeInternal ToInternal(ApprovalRouteStageTypeDto type)
    {
        ApprovalRouteStageTypeInternal result = type switch
        {
            ApprovalRouteStageTypeDto.ParallelAny => ApprovalRouteStageTypeInternal.ParallelAny,
            ApprovalRouteStageTypeDto.ParallelAll => ApprovalRouteStageTypeInternal.ParallelAll,
            ApprovalRouteStageTypeDto.Sequential => ApprovalRouteStageTypeInternal.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
