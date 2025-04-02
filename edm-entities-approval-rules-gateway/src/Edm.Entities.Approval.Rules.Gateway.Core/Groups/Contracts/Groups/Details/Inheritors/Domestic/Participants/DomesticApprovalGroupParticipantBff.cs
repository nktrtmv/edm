using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;

public sealed class DomesticApprovalGroupParticipantBff
{
    public DomesticApprovalGroupParticipantSourceBff? MainUserSource { get; init; }
    public DomesticApprovalGroupParticipantSourceBff[] SubstituteUsersSources { get; init; } = [];

    public required EntityConditionBff Condition { get; init; }

    public bool IsSubstitutionDisabled { get; init; }
}
