using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic.ValueObjects.Participants;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic;

public sealed class DomesticRouteGroup : RouteGroup
{
    public DomesticRouteGroup(string name, RouteParticipant[] participants) : base(name)
    {
        Participants = participants;
    }

    public RouteParticipant[] Participants { get; }

    public override string ToString()
    {
        string participants = string.Join<RouteParticipant>(", ", Participants);

        return $"{{ {BaseToString()}, Participants: [{participants}] }}";
    }
}
