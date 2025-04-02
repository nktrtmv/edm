using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Types;

internal static class RouteStageTypeInternalConverter
{
    internal static ApprovalRouteStageTypeDto ToDto(RouteStageTypeInternal type)
    {
        ApprovalRouteStageTypeDto result = type switch
        {
            RouteStageTypeInternal.ParallelAny => ApprovalRouteStageTypeDto.ParallelAny,
            RouteStageTypeInternal.ParallelAll => ApprovalRouteStageTypeDto.ParallelAll,
            RouteStageTypeInternal.Sequential => ApprovalRouteStageTypeDto.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
