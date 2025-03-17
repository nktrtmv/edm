using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Types.Mappers;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.Factories;

public static class RouteStageFactory
{
    public static RouteStage CreateFrom(ApprovalGraphStageNode node, RouteGroup[] groups)
    {
        RouteStageType type = RouteStageTypeConverter.FromGraphStageNodeType(node.Type);

        RouteStage result = CreateFrom(node.Id.ToString(), node.DisplayName, type, groups);

        return result;
    }

    internal static RouteStage CreateFrom(string id, string name, RouteStageType type, params RouteGroup[] groups)
    {
        var result = new RouteStage(id, name, type, groups);

        return result;
    }
}
