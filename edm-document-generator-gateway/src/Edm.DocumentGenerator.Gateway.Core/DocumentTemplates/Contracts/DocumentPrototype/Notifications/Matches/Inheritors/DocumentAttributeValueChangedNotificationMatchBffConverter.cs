using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches.Inheritors;

internal static class DocumentAttributeValueChangedNotificationMatchBffConverter
{
    public static DocumentAttributeValueChangedNotificationMatchBff ToBff(DocumentAttributeValueChangedNotificationMatchDto match)
    {
        var result = new DocumentAttributeValueChangedNotificationMatchBff
        {
            AttributeId = match.AttributeId
        };

        return result;
    }

    public static DocumentNotificationMatchDto AttributeValueChangeToDto(DocumentAttributeValueChangedNotificationMatchBff match)
    {
        var asAttributeValueChanged = new DocumentAttributeValueChangedNotificationMatchDto
        {
            AttributeId = match.AttributeId
        };

        var result = new DocumentNotificationMatchDto
        {
            AsAttributeValueChanged = asAttributeValueChanged
        };

        return result;
    }
}
