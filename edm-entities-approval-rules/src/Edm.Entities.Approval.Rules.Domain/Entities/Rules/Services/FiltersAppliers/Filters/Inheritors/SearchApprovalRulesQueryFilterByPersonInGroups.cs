using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Filters.Inheritors;

public sealed class SearchApprovalRulesQueryFilterByPersonInGroups : SearchApprovalRulesQueryFilter
{
    public SearchApprovalRulesQueryFilterByPersonInGroups(Id<User> personId)
    {
        PersonId = personId;
    }

    public Id<User> PersonId { get; }
}
