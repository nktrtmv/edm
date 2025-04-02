using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Enrichers;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts.Factories;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Sources.Attributes;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get;

public sealed class GetApprovalGraphsQueryService : ApprovalGraphsServiceBase
{
    public GetApprovalGraphsQueryService(
        ApprovalGraphsService.ApprovalGraphsServiceClient graphs,
        IServiceProvider services,
        IEnumerable<IEnricherSource> sources)
        : base(graphs)
    {
        Services = services;
        Sources = sources;
    }

    private IServiceProvider Services { get; }
    private IEnumerable<IEnricherSource> Sources { get; }

    public async Task<GetApprovalGraphsQueryResponseBff> Get(GetApprovalGraphsQueryBff query, CancellationToken cancellationToken)
    {
        var request = GetApprovalGraphsQueryBffConverter.ToDto(query);

        var response = await Graphs.GetAsync(request, cancellationToken: cancellationToken);

        var context = ApprovalEnrichersContextFactory.Create(query.ApprovalRuleKey.EntityTypeKey);

        var result = GetApprovalGraphsQueryResponseBffConverter.FromDto(response, context);

        var attributesSource = EntityTypeAttributeDtoEnricherSource.Create(Services, response.Attributes);

        var groupsSource = GetApprovalGraphsQueryResponseGroupEnricherSource.Create(Services, response.Groups);

        IEnricherSource[] sources = Sources
            .Prepend(groupsSource)
            .Prepend(attributesSource)
            .ToArray();

        await context.Enrich(sources, cancellationToken);

        return result;
    }
}
