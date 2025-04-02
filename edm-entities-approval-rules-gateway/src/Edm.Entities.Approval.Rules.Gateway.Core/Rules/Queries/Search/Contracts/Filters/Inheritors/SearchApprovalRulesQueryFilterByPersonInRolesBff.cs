namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters.Inheritors;

public sealed class SearchApprovalRulesQueryFilterByPersonInRolesBff : SearchApprovalRulesQueryFilterBff
{
    public required string PersonId { get; init; }
}
