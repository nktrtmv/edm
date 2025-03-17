using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants;

internal static class DomesticApprovalGroupParticipantInternalConverter
{
    internal static DomesticApprovalGroupParticipantInternal FromDto(DomesticApprovalGroupParticipantDto participant)
    {
        DomesticApprovalGroupParticipantSourceInternal mainParticipantSource = FetchMainParticipantSource(participant);

        DomesticApprovalGroupParticipantSourceInternal[] substituteParticipantsSources = FetchSubstituteParticipantsSources(participant);

        EntityConditionInternal condition =
            EntityConditionInternalConverter.FromDto(participant.Condition);

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipantInternal(mainParticipantSource, substituteParticipantsSources, condition, isSubstitutionDisabled);

        return result;
    }

    internal static DomesticApprovalGroupParticipantDto ToDto(DomesticApprovalGroupParticipantInternal participant)
    {
        DomesticApprovalGroupParticipantSourceDto mainUserSource = DomesticApprovalGroupParticipantSourceDtoConverter.FromInternal(participant.MainParticipantSource);

        DomesticApprovalGroupParticipantSourceDto[] substituteParticipantsSources =
            participant.SubstituteParticipantsSources.Select(DomesticApprovalGroupParticipantSourceDtoConverter.FromInternal).ToArray();

        EntityConditionDto condition = EntityConditionInternalConverter.ToDto(participant.Condition);

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipantDto
        {
            MainParticipantSource = mainUserSource,
            SubstituteParticipantsSources = { substituteParticipantsSources },
            Condition = condition,
            IsSubstitutionDisabled = isSubstitutionDisabled,

            // For backward compability
            MainUserId = (participant.MainParticipantSource as UserDomesticApprovalGroupParticipantSourceInternal)?.UserId ?? string.Empty,
            SubstituteUsersIds = { participant.SubstituteParticipantsSources.OfType<UserDomesticApprovalGroupParticipantSourceInternal>().Select(p => p.UserId) }
        };

        return result;
    }

    private static DomesticApprovalGroupParticipantSourceInternal FetchMainParticipantSource(DomesticApprovalGroupParticipantDto participant)
    {
        DomesticApprovalGroupParticipantSourceInternal result = participant.MainParticipantSource is null
            ? new UserDomesticApprovalGroupParticipantSourceInternal(participant.MainUserId)
            : DomesticApprovalGroupParticipantSourceDtoConverter.ToInternal(participant.MainParticipantSource); // For backward compability

        return result;
    }

    private static DomesticApprovalGroupParticipantSourceInternal[] FetchSubstituteParticipantsSources(DomesticApprovalGroupParticipantDto participant)
    {
        DomesticApprovalGroupParticipantSourceInternal[] result;

        if (participant.SubstituteParticipantsSources.Count > 0)
        {
            result = participant.SubstituteParticipantsSources.Select(DomesticApprovalGroupParticipantSourceDtoConverter.ToInternal).ToArray();
        }
        else if (participant.SubstituteUsersIds.Count > 0) // For backward compability
        {
            result = participant.SubstituteUsersIds
                .Select(i => new UserDomesticApprovalGroupParticipantSourceInternal(i))
                .ToArray<DomesticApprovalGroupParticipantSourceInternal>();
        }
        else
        {
            result = [];
        }

        return result;
    }
}
