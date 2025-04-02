using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters.Inheritors;

public sealed class SearchApprovalRulesQueryFilterByPersonInGroupsInternal : SearchApprovalRulesQueryFilterInternal
{
    public SearchApprovalRulesQueryFilterByPersonInGroupsInternal(Id<UserInternal> personId)
    {
        PersonId = personId;
    }

    public Id<UserInternal> PersonId { get; }
}
