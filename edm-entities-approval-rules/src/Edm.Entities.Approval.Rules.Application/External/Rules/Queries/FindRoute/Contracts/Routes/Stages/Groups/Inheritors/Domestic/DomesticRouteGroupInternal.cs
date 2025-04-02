using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic;

public sealed class DomesticRouteGroupInternal : RouteGroupInternal
{
    internal DomesticRouteGroupInternal(string name, RouteParticipantInternal[] participants)
        : base(name)
    {
        Participants = participants;
    }

    public RouteParticipantInternal[] Participants { get; }
}
