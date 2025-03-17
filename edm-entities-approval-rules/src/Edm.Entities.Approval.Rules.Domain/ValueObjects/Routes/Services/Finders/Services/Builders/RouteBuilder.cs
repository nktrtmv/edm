using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Contexts;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Builders.Stages;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Enumerators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Chief;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Types;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders;

internal static class RouteBuilder
{
    internal static Route Build(ApprovalRule rule, ApprovalGraph graph, Entity entity, ApprovalGroup[] groups)
    {
        var context = new RouteStageBuilderContext(entity, groups, rule);

        RouteStage[] chiefStages = CreateChiefStages(graph, entity);

        RouteStage[] nodeStages = CreateRouteStages(graph, context);

        RouteStage[] stages = chiefStages
            .Concat(nodeStages)
            .ToArray();

        Route result = RouteFactory.CreateNew(graph.DisplayName, rule.Audit.Brief.UpdatedAt.Value, stages);

        return result;
    }

    private static RouteStage[] CreateChiefStages(ApprovalGraph graph, Entity entity)
    {
        bool isChiefApprovalRequired = graph.ChiefApproval.IsRequired && graph.ChiefApproval.Condition.IsMet(entity);

        if (!isChiefApprovalRequired)
        {
            return [];
        }

        RouteStage stage = RouteStageFactory.CreateFrom(string.Empty, "Руководитель инициатора", RouteStageType.Sequential, ChiefRouteGroup.Instance);

        RouteStage[] result = { stage };

        return result;
    }

    private static RouteStage[] CreateRouteStages(ApprovalGraph graph, RouteStageBuilderContext context)
    {
        ApprovalGraphStageNode[] nodes = new GraphNodesEnumerator(graph, context.Entity)
            .Enumerate()
            .OfType<ApprovalGraphStageNode>()
            .ToArray();

        var index = 0;

        RouteStage[] result = nodes
            .Select(n => CreateRouteStage(n, context, ++index))
            .OfType<RouteStage>()
            .ToArray();

        return result;
    }

    private static RouteStage? CreateRouteStage(ApprovalGraphStageNode node, RouteStageBuilderContext context, int index)
    {
        try
        {
            RouteStage? result = RouteStageBuilder.Build(node, context);

            return result;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Failed to create route stage.\nNode: {node}", e);
        }
    }
}
