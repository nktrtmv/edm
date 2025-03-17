using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search;

public sealed class SearchApprovalRulesQueryService : ApprovalRulesServiceBase
{
    public SearchApprovalRulesQueryService(
        ApprovalRulesService.ApprovalRulesServiceClient rules,
        IEnumerable<IEnricherSource> enricherSources)
        : base(rules)
    {
        EnricherSources = enricherSources;
    }

    private IEnumerable<IEnricherSource> EnricherSources { get; }

    public async Task<SearchApprovalRulesQueryResponseBff> Search(SearchApprovalRulesQueryBff queryBff, CancellationToken cancellationToken)
    {
        var query = SearchApprovalRulesQueryBffConverter.ToDto(queryBff);

        var response = await Rules.SearchAsync(query, cancellationToken: cancellationToken);

        var context = new EnrichersContext();

        var result = SearchApprovalRulesQueryResponseBffConverter.FromDto(response, context);

        await context.Enrich(EnricherSources, cancellationToken);

        return result;
    }
}
