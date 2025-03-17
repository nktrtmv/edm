using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;

public sealed class RouteParticipantInternal
{
    internal RouteParticipantInternal(Id<UserInternal> mainPersonId, Id<UserInternal>[] substitutePersonsIds, bool isSubstitutionDisabled)
    {
        MainPersonId = mainPersonId;
        SubstitutePersonsIds = substitutePersonsIds;
        IsSubstitutionDisabled = isSubstitutionDisabled;
    }

    public Id<UserInternal> MainPersonId { get; }
    public Id<UserInternal>[] SubstitutePersonsIds { get; }
    public bool IsSubstitutionDisabled { get; }
}
