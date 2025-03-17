using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Matches.AttributeValueChanged;

internal static class DocumentAttributeValueChangedNotificationMatchDtoConverter
{
    internal static DocumentNotificationMatchDto FromInternal(DocumentAttributeValueChangedNotificationMatchInternal match)
    {
        var attributeId = IdConverterTo.ToString(match.AttributeId);

        var result = new DocumentNotificationMatchDto
        {
            AsAttributeValueChanged = new DocumentAttributeValueChangedNotificationMatchDto
            {
                AttributeId = attributeId
            }
        };

        return result;
    }

    internal static DocumentNotificationMatchInternal ToInternal(DocumentAttributeValueChangedNotificationMatchDto match)
    {
        Id<DocumentAttributeInternal> attributeId = IdConverterFrom<DocumentAttributeInternal>.FromString(match.AttributeId);

        var result = new DocumentAttributeValueChangedNotificationMatchInternal(attributeId);

        return result;
    }
}
