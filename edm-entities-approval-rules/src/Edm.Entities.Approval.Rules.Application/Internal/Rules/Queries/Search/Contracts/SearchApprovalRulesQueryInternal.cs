using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts;

public sealed record SearchApprovalRulesQueryInternal(DomainId DomainId, bool IsActiveRequired, SearchApprovalRulesQueryFilterInternal[] Filters)
    : IRequest<SearchApprovalRulesQueryResponseInternal>
{
    internal DomainId DomainId { get; } = DomainId;
    internal bool IsActiveRequired { get; } = IsActiveRequired;
    internal SearchApprovalRulesQueryFilterInternal[] Filters { get; } = Filters;
}
