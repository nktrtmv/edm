using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;

internal static class RouteParticipantInternalConverter
{
    internal static RouteParticipantInternal FromDomain(RouteParticipant person)
    {
        Id<UserInternal> mainParticipantId =
            IdConverterFrom<UserInternal>.From(person.MainPersonId);

        Id<UserInternal>[] substitutePersonsIds =
            person.SubstitutePersonsIds.Select(IdConverterFrom<UserInternal>.From).ToArray();

        bool isSubstitutionDisabled = person.IsSubstitutionDisabled;

        var result = new RouteParticipantInternal(mainParticipantId, substitutePersonsIds, isSubstitutionDisabled);

        return result;
    }
}
