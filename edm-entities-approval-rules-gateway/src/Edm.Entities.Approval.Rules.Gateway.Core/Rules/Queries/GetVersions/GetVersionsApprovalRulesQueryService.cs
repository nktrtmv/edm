using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions;

public sealed class GetVersionsApprovalRulesQueryService : ApprovalRulesServiceBase
{
    public GetVersionsApprovalRulesQueryService(ApprovalRulesService.ApprovalRulesServiceClient rules, IEnumerable<IEnricherSource> enricherSources) : base(rules)
    {
        EnricherSources = enricherSources;
    }

    private IEnumerable<IEnricherSource> EnricherSources { get; }

    public async Task<GetVersionsApprovalRulesQueryResponseBff> GetVersions(GetVersionsApprovalRulesQueryBff query, CancellationToken cancellationToken)
    {
        var request = GetVersionsApprovalRulesQueryBffConverter.ToDto(query);

        var response = await Rules.GetVersionsAsync(request, cancellationToken: cancellationToken);

        var context = new EnrichersContext();

        var result = GetVersionsApprovalRulesQueryResponseBffConverter.FromDto(response, context);

        await context.Enrich(EnricherSources, cancellationToken);

        return result;
    }
}
