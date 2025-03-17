using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants.Sources.AttributeIds;

internal static class AttributeIdDomesticApprovalGroupParticipantSourceDbConverter
{
    public static AttributeDomesticApprovalGroupParticipantSource ToDomain(AttributeDomesticApprovalGroupParticipantSourceDb source)
    {
        var result = new AttributeDomesticApprovalGroupParticipantSource(source.AttributeId);

        return result;
    }

    public static DomesticApprovalGroupParticipantSourceDb FromDomain(AttributeDomesticApprovalGroupParticipantSource source)
    {
        var asAttribute = new AttributeDomesticApprovalGroupParticipantSourceDb
        {
            AttributeId = source.AttributeId
        };

        var result = new DomesticApprovalGroupParticipantSourceDb
        {
            AsAttribute = asAttribute
        };

        return result;
    }
}
