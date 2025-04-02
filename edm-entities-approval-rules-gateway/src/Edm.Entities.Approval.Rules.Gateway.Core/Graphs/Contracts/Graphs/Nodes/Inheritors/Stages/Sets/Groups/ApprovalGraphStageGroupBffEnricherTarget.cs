using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics.SingleValue;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets.Groups;

public sealed class ApprovalGraphStageGroupBffEnricherTarget : SingleValueEnricherTargetGeneric<string, GetApprovalGraphsQueryResponseGroup>
{
    internal ApprovalGraphStageGroupBffEnricherTarget(ApprovalGraphStageGroupBff target)
    {
        Target = target;
    }

    private ApprovalGraphStageGroupBff Target { get; }

    protected override string GetKey()
    {
        return Target.Id;
    }

    protected override void EnrichTarget(GetApprovalGraphsQueryResponseGroup value)
    {
        Target.DisplayName = value.DisplayName;
    }
}
