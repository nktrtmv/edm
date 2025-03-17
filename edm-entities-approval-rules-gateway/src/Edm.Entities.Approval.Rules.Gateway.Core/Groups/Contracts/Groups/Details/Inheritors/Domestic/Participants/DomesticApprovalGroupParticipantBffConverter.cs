using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;

internal static class DomesticApprovalGroupParticipantBffConverter
{
    internal static DomesticApprovalGroupParticipantBff FromDto(DomesticApprovalGroupParticipantDto participant, ApprovalEnrichersContext context)
    {
        var mainUserSource = DomesticApprovalGroupParticipantSourceBffConverter.FromDto(participant.MainParticipantSource, context);

        DomesticApprovalGroupParticipantSourceBff[] substituteUsersSources =
            participant.SubstituteParticipantsSources.Select(s => DomesticApprovalGroupParticipantSourceBffConverter.FromDto(s, context)).ToArray();

        var condition =
            EntityConditionBffConverter.FromDto(participant.Condition, context);

        var isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipantBff
        {
            MainUserSource = mainUserSource,
            SubstituteUsersSources = substituteUsersSources,
            Condition = condition,
            IsSubstitutionDisabled = isSubstitutionDisabled
        };

        return result;
    }

    internal static DomesticApprovalGroupParticipantDto ToDto(DomesticApprovalGroupParticipantBff participant)
    {
        var mainUserSource = DomesticApprovalGroupParticipantSourceBffConverter.ToDto(participant.MainUserSource!);

        var substituteUsersSources =
            participant.SubstituteUsersSources.Select(DomesticApprovalGroupParticipantSourceBffConverter.ToDto).ToArray();

        var condition = EntityConditionBffConverter.ToDto(participant.Condition);

        var isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipantDto
        {
            MainParticipantSource = mainUserSource,
            SubstituteParticipantsSources = { substituteUsersSources },
            Condition = condition,
            IsSubstitutionDisabled = isSubstitutionDisabled
        };

        return result;
    }
}
