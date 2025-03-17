using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts;

public sealed class SearchApprovalRulesQueryBff
{
    public required string DomainId { get; init; }
    public required bool IsActiveRequired { get; init; }
    public required SearchApprovalRulesQueryFilterBff[] Filters { get; init; }
}
