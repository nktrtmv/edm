using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;

internal static class AttributeDomesticApprovalGroupParticipantSourceInternalConverter
{
    public static AttributeDomesticApprovalGroupParticipantSourceInternal FromDomain(AttributeDomesticApprovalGroupParticipantSource source)
    {
        var result = new AttributeDomesticApprovalGroupParticipantSourceInternal(source.AttributeId);

        return result;
    }

    public static AttributeDomesticApprovalGroupParticipantSource ToDomain(AttributeDomesticApprovalGroupParticipantSourceInternal source)
    {
        var result = new AttributeDomesticApprovalGroupParticipantSource(source.AttributeId);

        return result;
    }
}
