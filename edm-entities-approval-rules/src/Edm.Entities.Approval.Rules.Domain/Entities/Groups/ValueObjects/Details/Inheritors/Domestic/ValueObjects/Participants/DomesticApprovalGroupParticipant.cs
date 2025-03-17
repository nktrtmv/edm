using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;

public sealed class DomesticApprovalGroupParticipant(
    DomesticApprovalGroupParticipantSource mainParticipantSource,
    DomesticApprovalGroupParticipantSource[] substituteParticipantsSources,
    EntityCondition condition,
    bool isSubstitutionDisabled)
{
    public DomesticApprovalGroupParticipantSource MainParticipantSource { get; } = mainParticipantSource;
    public DomesticApprovalGroupParticipantSource[] SubstituteParticipantsSources { get; } = substituteParticipantsSources;
    public EntityCondition Condition { get; } = condition;
    public bool IsSubstitutionDisabled { get; } = isSubstitutionDisabled;

    public override string ToString()
    {
        string? substituteParticipantsSources = string.Join<DomesticApprovalGroupParticipantSource>(", ", SubstituteParticipantsSources);

        return $"{{ MainParticipantSource: {MainParticipantSource}, SubstituteParticipantsSources: [{substituteParticipantsSources}], Condition: {Condition} }}";
    }
}
