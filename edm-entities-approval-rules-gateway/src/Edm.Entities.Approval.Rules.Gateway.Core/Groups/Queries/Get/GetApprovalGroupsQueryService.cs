using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts.Factories;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Sources.Attributes;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get;

public sealed class GetApprovalGroupsQueryService : ApprovalGroupsServiceBase
{
    public GetApprovalGroupsQueryService(
        ApprovalGroupsService.ApprovalGroupsServiceClient groups,
        IServiceProvider services,
        IEnumerable<IEnricherSource> sources) : base(groups)
    {
        Services = services;
        Sources = sources;
    }

    private IServiceProvider Services { get; }
    private IEnumerable<IEnricherSource> Sources { get; }

    public async Task<GetApprovalGroupsQueryResponseBff> Get(GetApprovalGroupsQueryBff query, CancellationToken cancellationToken)
    {
        var request = GetApprovalGroupsQueryBffConverter.ToDto(query);

        var response = await Groups.GetAsync(request, cancellationToken: cancellationToken);

        var context = ApprovalEnrichersContextFactory.Create(query.ApprovalRuleKey.EntityTypeKey);

        var result = GetApprovalGroupsQueryResponseBffConverter.FromDto(response, context);

        var attributesSource = EntityTypeAttributeDtoEnricherSource.Create(Services, response.Attributes);

        IEnricherSource[] sources = Sources
            .Prepend(attributesSource)
            .ToArray();

        await context.Enrich(sources, cancellationToken);

        return result;
    }
}
