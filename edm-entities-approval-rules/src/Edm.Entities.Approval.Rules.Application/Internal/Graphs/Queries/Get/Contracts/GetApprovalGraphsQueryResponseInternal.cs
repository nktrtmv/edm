using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts;

public sealed class GetApprovalGraphsQueryResponseInternal
{
    public GetApprovalGraphsQueryResponseInternal(
        ApprovalGraphInternal graph,
        EntityTypeAttributeInternal[] attributes,
        GetApprovalGraphsQueryResponseGroupInternal[] groups,
        ConcurrencyToken<GetApprovalGraphsQueryResponseInternal> concurrencyToken)
    {
        Graph = graph;
        Attributes = attributes;
        Groups = groups;
        ConcurrencyToken = concurrencyToken;
    }

    public ApprovalGraphInternal Graph { get; }
    public EntityTypeAttributeInternal[] Attributes { get; }
    public GetApprovalGraphsQueryResponseGroupInternal[] Groups { get; }
    public ConcurrencyToken<GetApprovalGraphsQueryResponseInternal> ConcurrencyToken { get; }
}
