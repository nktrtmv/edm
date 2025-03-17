using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;

public sealed record DomesticApprovalGroupParticipantInternal(
    DomesticApprovalGroupParticipantSourceInternal MainParticipantSource,
    DomesticApprovalGroupParticipantSourceInternal[] SubstituteParticipantsSources,
    EntityConditionInternal Condition,
    bool IsSubstitutionDisabled);
