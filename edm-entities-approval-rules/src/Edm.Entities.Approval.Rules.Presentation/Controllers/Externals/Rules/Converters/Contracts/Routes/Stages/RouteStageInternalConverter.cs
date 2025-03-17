using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Types;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages;

internal static class RouteStageInternalConverter
{
    internal static ApprovalRouteStageDto ToDto(RouteStageInternal stage)
    {
        ApprovalRouteStageTypeDto type = RouteStageTypeInternalConverter.ToDto(stage.Type);

        ApprovalRouteGroupDto[] groups = stage.Groups.Select(RouteGroupInternalConverter.ToDto).ToArray();

        var result = new ApprovalRouteStageDto
        {
            Name = stage.Name,
            Type = type,
            Groups = { groups },
            Id = stage.Id
        };

        return result;
    }
}
