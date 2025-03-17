using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit;

public sealed class GetActivationAuditApprovalRulesQueryService : ApprovalRulesServiceBase
{
    public GetActivationAuditApprovalRulesQueryService(ApprovalRulesService.ApprovalRulesServiceClient rules, IEnumerable<IEnricherSource> enricherSources) : base(rules)
    {
        EnricherSources = enricherSources;
    }

    private IEnumerable<IEnricherSource> EnricherSources { get; }

    public async Task<GetActivationAuditApprovalRulesQueryResponseBff> GetActivationAudit(
        GetActivationAuditApprovalRulesQueryBff query,
        CancellationToken cancellationToken)
    {
        var request =
            GetActivationAuditApprovalRulesQueryBffConverter.ToDto(query);

        var response =
            await Rules.GetActivationAuditAsync(request, cancellationToken: cancellationToken);

        var context = new EnrichersContext();

        var result =
            GetActivationAuditApprovalRulesQueryResponseBffConverter.FromDto(response, context);

        await context.Enrich(EnricherSources, cancellationToken);

        return result;
    }
}
