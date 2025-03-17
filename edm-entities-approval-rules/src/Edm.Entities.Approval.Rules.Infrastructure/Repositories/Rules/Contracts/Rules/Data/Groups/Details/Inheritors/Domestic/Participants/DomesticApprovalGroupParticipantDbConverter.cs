using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants.Sources;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants;

internal static class DomesticApprovalGroupParticipantDbConverter
{
    internal static DomesticApprovalGroupParticipantDb FromDomain(DomesticApprovalGroupParticipant participant)
    {
        DomesticApprovalGroupParticipantSourceDb mainParticipantSource =
            DomesticApprovalGroupParticipantSourceDbConverter.FromDomain(participant.MainParticipantSource);

        DomesticApprovalGroupParticipantSourceDb[] substituteParticipantsSources =
            participant.SubstituteParticipantsSources.Select(DomesticApprovalGroupParticipantSourceDbConverter.FromDomain).ToArray();

        EntityConditionDb condition = EntityConditionDbConverter.FromDomain(participant.Condition);

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipantDb
        {
            MainParticipantSource = mainParticipantSource,
            SubstituteParticipantsSources = { substituteParticipantsSources },
            Condition = condition,
            IsSubstitutionDisabled = isSubstitutionDisabled
        };

        return result;
    }

    internal static DomesticApprovalGroupParticipant ToDomain(DomesticApprovalGroupParticipantDb participant)
    {
        DomesticApprovalGroupParticipantSource mainParticipantSource = FetchMainParticipantSource(participant);

        DomesticApprovalGroupParticipantSource[] substituteParticipantsSources = FetchSubstituteParticipantsSources(participant);

        EntityCondition condition = EntityConditionDbConverter.ToDomain(participant.Condition);

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipant(mainParticipantSource, substituteParticipantsSources, condition, isSubstitutionDisabled);

        return result;
    }

    private static DomesticApprovalGroupParticipantSource FetchMainParticipantSource(DomesticApprovalGroupParticipantDb participant)
    {
        DomesticApprovalGroupParticipantSource result;

        if (participant.MainParticipantSource is null) // For backward compability
        {
            Id<User> mainUserId = IdConverterFrom<User>.FromString(participant.MainUserId);

            result = new UserDomesticApprovalGroupParticipantSource(mainUserId);
        }
        else
        {
            result = DomesticApprovalGroupParticipantSourceDbConverter.ToDomain(participant.MainParticipantSource);
        }

        return result;
    }

    private static DomesticApprovalGroupParticipantSource[] FetchSubstituteParticipantsSources(DomesticApprovalGroupParticipantDb participant)
    {
        DomesticApprovalGroupParticipantSource[] result;

        if (participant.SubstituteParticipantsSources.Count > 0)
        {
            result = participant.SubstituteParticipantsSources.Select(DomesticApprovalGroupParticipantSourceDbConverter.ToDomain).ToArray();
        }
        else if (participant.SubstituteUsersIds.Count > 0) // For backward compability
        {
            result = participant.SubstituteUsersIds
                .Select(i => new UserDomesticApprovalGroupParticipantSource(IdConverterFrom<User>.FromString(i)))
                .ToArray<DomesticApprovalGroupParticipantSource>();
        }
        else
        {
            result = [];
        }

        return result;
    }
}
