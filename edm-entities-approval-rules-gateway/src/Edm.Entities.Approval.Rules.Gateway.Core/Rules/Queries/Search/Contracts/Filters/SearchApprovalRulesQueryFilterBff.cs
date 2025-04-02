using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters.Inheritors;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters;

[JsonDerivedType(typeof(SearchApprovalRulesQueryFilterByPersonInRolesBff), "ByPersonInRoles")]
public abstract class SearchApprovalRulesQueryFilterBff
{
}
