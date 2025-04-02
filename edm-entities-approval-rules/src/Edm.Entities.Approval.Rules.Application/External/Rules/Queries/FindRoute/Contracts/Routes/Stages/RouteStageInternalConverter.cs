using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages;

internal static class RouteStageInternalConverter
{
    internal static RouteStageInternal FromDomain(RouteStage stage)
    {
        RouteStageTypeInternal type = RouteStageTypeInternalConverter.FromDomain(stage.Type);

        RouteGroupInternal[] groups = stage.Groups.Select(RouteGroupInternalConverter.FromDomain).ToArray();

        var result = new RouteStageInternal(stage.Id, stage.Name, type, groups);

        return result;
    }
}
