using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.AttributeValueChanged;

internal static class DocumentAttributeValueChangedNotificationMatchInternalConverter
{
    internal static DocumentNotificationMatchInternal FromDomain(DocumentAttributeValueChangedNotificationMatch match)
    {
        Id<DocumentAttributeInternal> attributeId = IdConverterFrom<DocumentAttributeInternal>.From(match.AttributeId);

        var result = new DocumentAttributeValueChangedNotificationMatchInternal(attributeId);

        return result;
    }

    internal static DocumentNotificationMatch ToDomain(DocumentAttributeValueChangedNotificationMatchInternal match)
    {
        Id<DocumentAttribute> attributeId = IdConverterFrom<DocumentAttribute>.From(match.AttributeId);

        var result = new DocumentAttributeValueChangedNotificationMatch(attributeId);

        return result;
    }
}
