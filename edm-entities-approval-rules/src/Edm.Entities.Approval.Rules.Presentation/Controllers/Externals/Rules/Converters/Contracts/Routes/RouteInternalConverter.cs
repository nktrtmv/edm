using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes;

internal static class RouteInternalConverter
{
    internal static ApprovalRouteDto ToDto(RouteInternal route)
    {
        ApprovalRouteStageDto[] stages = route.Stages.Select(RouteStageInternalConverter.ToDto).ToArray();

        var result = new ApprovalRouteDto
        {
            Name = route.Name,
            Stages = { stages },
            UpdatedDate = Timestamp.FromDateTime(route.UpdatedTime.ToUniversalTime())
        };

        return result;
    }
}
