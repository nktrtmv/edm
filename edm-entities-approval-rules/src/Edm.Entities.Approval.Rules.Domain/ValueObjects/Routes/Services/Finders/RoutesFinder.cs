using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders;

public static class RoutesFinder
{
    public static Route FindRoute(ApprovalRule rule, Entity entity, string tag)
    {
        try
        {
            ApprovalGraph graph = GetActiveGraph(rule, tag);

            Route result = BuildRoute(rule, entity, graph);

            return result;
        }
        catch (Exception e)
        {
            throw new ApplicationException(
                $"""
                 Failed to find route.
                 ApprovalRule: {rule}
                 Entity: {entity}
                 Tag: '{tag}'
                 """,
                e);
        }
    }

    private static ApprovalGraph GetActiveGraph(ApprovalRule rule, string tag)
    {
        ApprovalGraph? graph = rule.Graphs.FirstOrDefault(g => g.Tag == tag && g.Status == ApprovalGraphStatus.Active);

        if (graph is not null)
        {
            return graph;
        }

        throw new ApplicationException("Active graph is not found.");
    }

    private static Route BuildRoute(ApprovalRule rule, Entity entity, ApprovalGraph graph)
    {
        try
        {
            Route result = RouteBuilder.Build(rule, graph, entity, rule.Groups);

            if (result.Stages.Any())
            {
                return result;
            }

            throw new ApplicationException("After applying conditions there should be at least 1 stage in result route.");
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Graph: {graph}", e);
        }
    }
}
