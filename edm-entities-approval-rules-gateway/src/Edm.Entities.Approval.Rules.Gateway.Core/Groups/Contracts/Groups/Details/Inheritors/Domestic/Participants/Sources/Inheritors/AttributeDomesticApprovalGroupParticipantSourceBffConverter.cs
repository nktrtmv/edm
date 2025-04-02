using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;

internal static class AttributeDomesticApprovalGroupParticipantSourceBffConverter
{
    public static AttributeDomesticApprovalGroupParticipantSourceBff FromDto(AttributeDomesticApprovalGroupParticipantSourceDto source, ApprovalEnrichersContext context)
    {
        var attribute = EntityTypeReferenceAttributeBffConverter.FromDto(source.AttributeId, context);

        var result = new AttributeDomesticApprovalGroupParticipantSourceBff(attribute);

        return result;
    }

    public static DomesticApprovalGroupParticipantSourceDto ToDto(AttributeDomesticApprovalGroupParticipantSourceBff source)
    {
        var asAttribute = new AttributeDomesticApprovalGroupParticipantSourceDto
        {
            AttributeId = source.Attribute.Data.Id
        };

        var result = new DomesticApprovalGroupParticipantSourceDto
        {
            AsAttribute = asAttribute
        };

        return result;
    }
}
