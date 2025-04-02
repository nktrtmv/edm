using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets.Groups;

internal static class ApprovalGraphStageGroupBffConverter
{
    internal static ApprovalGraphStageGroupBff FromDto(string id, EnrichersContext context)
    {
        var result = new ApprovalGraphStageGroupBff
        {
            Id = id
        };

        var enricher = new ApprovalGraphStageGroupBffEnricherTarget(result);

        context.Add(enricher);

        return result;
    }
}
