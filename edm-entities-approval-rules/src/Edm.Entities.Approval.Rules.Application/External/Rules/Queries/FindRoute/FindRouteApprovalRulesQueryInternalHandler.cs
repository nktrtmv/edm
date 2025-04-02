using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Services.Finders.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute;

[UsedImplicitly]
internal sealed class FindRouteApprovalRulesQueryInternalHandler(
    ActiveEntityApprovalRuleFinder rules,
    ILogger<FindRouteApprovalRulesQueryInternalHandler> logger)
    : IRequestHandler<FindRouteApprovalRulesQueryInternal, FindRouteApprovalRulesQueryResponseInternal>
{
    private ActiveEntityApprovalRuleFinder Rules { get; } = rules;
    private ILogger<FindRouteApprovalRulesQueryInternalHandler> Logger { get; } = logger;

    public async Task<FindRouteApprovalRulesQueryResponseInternal> Handle(FindRouteApprovalRulesQueryInternal request, CancellationToken cancellationToken)
    {
        (Entity entity, string tag) = FindRouteApprovalRulesQueryInternalConverter.ToDomain(request);

        ApprovalRule rule = await Rules.Find(entity, cancellationToken);

        Route route = RoutesFinder.FindRoute(rule, entity, tag);

        Logger.LogInformation("ROUTE FOUND: 🔎🔎🔎🔎🔎\n{Route}", route);

        FindRouteApprovalRulesQueryResponseInternal result = FindRouteQueryResponseInternalConverter.FromDomain(route, rule);

        return result;
    }
}
