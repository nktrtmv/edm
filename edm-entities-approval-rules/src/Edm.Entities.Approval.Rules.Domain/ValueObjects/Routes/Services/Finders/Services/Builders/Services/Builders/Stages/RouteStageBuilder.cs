using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Contexts;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Builders.Stages.Services.Builders.Domestic;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Builders.Stages;

internal static class RouteStageBuilder
{
    internal static RouteStage? Build(ApprovalGraphStageNode node, RouteStageBuilderContext context)
    {
        RouteGroup[] groups = BuildGroups(node, context);

        if (groups.Length == 0)
        {
            return null;
        }

        RouteStage result = RouteStageFactory.CreateFrom(node, groups);

        return result;
    }

    private static RouteGroup[] BuildGroups(ApprovalGraphStageNode node, RouteStageBuilderContext context)
    {
        Id<ApprovalGroup>[] groupsIds = node.Sets
            .Where(x => x.Condition.IsMet(context.Entity))
            .SelectMany(x => x.GroupsIds)
            .Distinct()
            .ToArray();

        ApprovalGroup[] groups = groupsIds
            .Select(context.GetRequiredGroup)
            .ToArray();

        RouteGroup[] result = groups
            .Select(g => Build(g, context.Entity, context.ApprovalRule))
            .OfType<RouteGroup>()
            .ToArray();

        return result;
    }

    private static RouteGroup? Build(ApprovalGroup group, Entity entity, ApprovalRule approvalRule)
    {
        RouteGroup? result = group.Details switch
        {
            DomesticApprovalGroupDetails d => DomesticRouteGroupBuilder.Build(d, group, entity, approvalRule),
            _ => throw new ArgumentTypeOutOfRangeException(group.Details)
        };

        return result;
    }
}
