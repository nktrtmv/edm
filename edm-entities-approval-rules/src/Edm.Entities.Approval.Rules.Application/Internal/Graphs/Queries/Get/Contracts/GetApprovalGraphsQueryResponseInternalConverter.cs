using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts;

internal static class GetApprovalGraphsQueryResponseInternalConverter
{
    internal static GetApprovalGraphsQueryResponseInternal FromDomain(ApprovalGraph graph, ApprovalRule rule)
    {
        ApprovalGraphInternal graphInternal = ApprovalGraphInternalConverter.FromDomain(graph);

        EntityTypeAttributeInternal[] attributes =
            rule.EntityType.Attributes.Select(EntityTypeAttributeInternalFromDomainConverter.FromDomain).ToArray();

        GetApprovalGraphsQueryResponseGroupInternal[] groups =
            rule.Groups.Select(GetApprovalGraphsQueryResponseGroupInternalConverter.FromDomain).ToArray();

        ConcurrencyToken<GetApprovalGraphsQueryResponseInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<GetApprovalGraphsQueryResponseInternal>.From(rule.ConcurrencyToken);

        var result = new GetApprovalGraphsQueryResponseInternal(graphInternal, attributes, groups, concurrencyToken);

        return result;
    }
}
