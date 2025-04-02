using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Attributes;

internal static class AttributeDomesticApprovalGroupParticipantSourceDtoConverter
{
    public static DomesticApprovalGroupParticipantSourceDto FromInternal(AttributeDomesticApprovalGroupParticipantSourceInternal source)
    {
        var asAttribute = new AttributeDomesticApprovalGroupParticipantSourceDto
        {
            AttributeId = source.AttributeId
        };

        var result = new DomesticApprovalGroupParticipantSourceDto
        {
            AsAttribute = asAttribute
        };

        return result;
    }

    public static AttributeDomesticApprovalGroupParticipantSourceInternal ToInternal(AttributeDomesticApprovalGroupParticipantSourceDto source)
    {
        var result = new AttributeDomesticApprovalGroupParticipantSourceInternal(source.AttributeId);

        return result;
    }
}
