using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic;

internal static class DomesticRouteGroupInternalConverter
{
    internal static DomesticRouteGroupInternal FromDomain(DomesticRouteGroup group)
    {
        RouteParticipantInternal[] participants =
            group.Participants.Select(RouteParticipantInternalConverter.FromDomain).ToArray();

        var result = new DomesticRouteGroupInternal(group.Name, participants);

        return result;
    }
}
