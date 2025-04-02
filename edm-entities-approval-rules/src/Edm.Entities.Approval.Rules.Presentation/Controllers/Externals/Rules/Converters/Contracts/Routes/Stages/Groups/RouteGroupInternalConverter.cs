using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Chief;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups.Inheritors.Chief;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups.Inheritors.Domestic;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups;

internal static class RouteGroupInternalConverter
{
    internal static ApprovalRouteGroupDto ToDto(RouteGroupInternal group)
    {
        ApprovalRouteGroupDto result = group switch
        {
            ChiefRouteGroupInternal => ChiefRouteGroupInternalConverter.ToDto(),
            DomesticRouteGroupInternal g => DomesticRouteGroupInternalConverter.ToDto(g),
            _ => throw new ArgumentTypeOutOfRangeException(group)
        };

        result.Name = group.Name;

        return result;
    }
}
