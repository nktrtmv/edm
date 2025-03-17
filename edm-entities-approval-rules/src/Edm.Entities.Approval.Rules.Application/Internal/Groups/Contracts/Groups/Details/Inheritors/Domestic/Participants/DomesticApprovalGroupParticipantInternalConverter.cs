using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;

internal static class DomesticApprovalGroupParticipantInternalConverter
{
    internal static DomesticApprovalGroupParticipantInternal FromDomain(DomesticApprovalGroupParticipant participant)
    {
        DomesticApprovalGroupParticipantSourceInternal mainParticipantSource =
            DomesticApprovalGroupParticipantSourceInternalConverter.FromDomain(participant.MainParticipantSource);

        DomesticApprovalGroupParticipantSourceInternal[] substituteParticipantsSources =
            participant.SubstituteParticipantsSources.Select(DomesticApprovalGroupParticipantSourceInternalConverter.FromDomain).ToArray();

        EntityConditionInternal condition =
            EntityConditionInternalConverter.FromDomain(participant.Condition);

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipantInternal(mainParticipantSource, substituteParticipantsSources, condition, isSubstitutionDisabled);

        return result;
    }

    internal static DomesticApprovalGroupParticipant ToDomain(DomesticApprovalGroupParticipantInternal participant)
    {
        DomesticApprovalGroupParticipantSource mainParticipantSource =
            DomesticApprovalGroupParticipantSourceInternalConverter.ToDomain(participant.MainParticipantSource);

        DomesticApprovalGroupParticipantSource[] substituteParticipantsSources =
            participant.SubstituteParticipantsSources.Select(DomesticApprovalGroupParticipantSourceInternalConverter.ToDomain).ToArray();

        EntityCondition condition =
            EntityConditionInternalConverter.ToDomain(participant.Condition);

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipant(mainParticipantSource, substituteParticipantsSources, condition, isSubstitutionDisabled);

        return result;
    }
}
