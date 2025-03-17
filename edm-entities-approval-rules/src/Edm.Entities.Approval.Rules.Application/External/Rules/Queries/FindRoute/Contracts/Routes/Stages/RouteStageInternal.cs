using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Types;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages;

public sealed record RouteStageInternal(
    string Id,
    string Name,
    RouteStageTypeInternal Type,
    RouteGroupInternal[] Groups);
