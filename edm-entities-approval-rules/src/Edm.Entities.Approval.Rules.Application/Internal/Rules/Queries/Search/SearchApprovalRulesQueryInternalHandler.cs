using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Appliers;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Filters;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search;

[UsedImplicitly]
internal sealed class SearchApprovalRulesQueryInternalHandler : IRequestHandler<SearchApprovalRulesQueryInternal, SearchApprovalRulesQueryResponseInternal>
{
    public SearchApprovalRulesQueryInternalHandler(IApprovalRulesRepository rules)
    {
        Rules = rules;
    }

    private IApprovalRulesRepository Rules { get; }

    public async Task<SearchApprovalRulesQueryResponseInternal> Handle(SearchApprovalRulesQueryInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = request.DomainId;

        ApprovalRule[] rules = await Rules.GetAll(domainId, request.IsActiveRequired, cancellationToken);

        SearchApprovalRulesQueryFilter[] filters =
            request.Filters.Select(SearchApprovalRulesQueryFilterInternalConverter.ToDomain).ToArray();

        rules = SearchApprovalRulesQueryFiltersAppliers.Apply(rules, filters);

        SearchApprovalRulesQueryResponseApprovalRuleInternal[] rulesInternal =
            rules.Select(SearchApprovalRulesQueryResponseApprovalRuleInternalConverter.FromDomain).ToArray();

        var result = new SearchApprovalRulesQueryResponseInternal(rulesInternal);

        return result;
    }
}
