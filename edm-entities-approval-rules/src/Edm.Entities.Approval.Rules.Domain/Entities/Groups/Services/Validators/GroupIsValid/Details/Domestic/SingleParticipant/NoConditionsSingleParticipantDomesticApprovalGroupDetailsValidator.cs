using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid.Details.Domestic.SingleParticipant;

internal static class NoConditionsSingleParticipantDomesticApprovalGroupDetailsValidator
{
    internal static void Validate(DomesticApprovalGroupDetails details)
    {
        if (details.Participants.Length < 2)
        {
            return;
        }

        int potentialParticipantsWithoutConditions = details.Participants.Count(e => e.Condition is EntityNoneCondition);

        if (potentialParticipantsWithoutConditions == 0)
        {
            return;
        }

        throw new ApplicationException(
            $"""
             Domestic approval group marked as `Single Participant` has {potentialParticipantsWithoutConditions} potential participants without conditions.
             DomesticApprovalGroupDetails: {details}
             """);
    }
}
