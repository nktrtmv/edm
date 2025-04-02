using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid.Details.Domestic.SingleParticipant;

internal static class DuplicationConditionsSingleParticipantDomesticApprovalGroupDetailsValidator
{
    internal static void Validate(DomesticApprovalGroupDetails details)
    {
        int potentialParticipantsWithDuplicateConditions = details.Participants
            .Where(p => p.Condition is not EntityNoneCondition)
            .GroupBy(p => p.Condition)
            .Select(c => c.Count())
            .Where(c => c > 1)
            .Sum();

        if (potentialParticipantsWithDuplicateConditions == 0)
        {
            return;
        }

        throw new ApplicationException(
            $"""
             Domestic approval group marked as `Single Participant` has {potentialParticipantsWithDuplicateConditions} potential participants with duplicate conditions.
             DomesticApprovalGroupDetails: {details}
             """);
    }
}
