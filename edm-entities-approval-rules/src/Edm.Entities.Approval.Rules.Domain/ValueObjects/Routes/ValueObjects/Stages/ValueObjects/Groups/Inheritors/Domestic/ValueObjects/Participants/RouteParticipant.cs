using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic.ValueObjects.Participants;

public sealed class RouteParticipant
{
    internal RouteParticipant(Id<User> mainPersonId, Id<User>[] substitutePersonsIds, bool isSubstitutionDisabled)
    {
        MainPersonId = mainPersonId;
        SubstitutePersonsIds = substitutePersonsIds;
        IsSubstitutionDisabled = isSubstitutionDisabled;
    }

    public Id<User> MainPersonId { get; }
    public Id<User>[] SubstitutePersonsIds { get; }
    public bool IsSubstitutionDisabled { get; }

    public override string ToString()
    {
        string substitutePersonsIds = string.Join<Id<User>>(", ", SubstitutePersonsIds);

        return $"{{ MainPersonId: {MainPersonId}, SubstitutePersonsIds: [{substitutePersonsIds}], IsSubstitutionDisabled: {IsSubstitutionDisabled} }}";
    }
}
