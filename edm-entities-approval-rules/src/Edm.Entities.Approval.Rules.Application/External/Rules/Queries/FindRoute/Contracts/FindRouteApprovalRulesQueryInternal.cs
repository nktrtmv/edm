using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Entities;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;

public sealed class FindRouteApprovalRulesQueryInternal : IRequest<FindRouteApprovalRulesQueryResponseInternal>
{
    public FindRouteApprovalRulesQueryInternal(EntityInternal entity, string tag)
    {
        Entity = entity;
        Tag = tag;
    }

    internal EntityInternal Entity { get; }
    internal string Tag { get; }
}
