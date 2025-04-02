using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes;

public sealed record RouteInternal(
    string Name,
    RouteStageInternal[] Stages,
    DateTime UpdatedTime);
