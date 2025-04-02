using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.AttributeValueChanged;

public sealed class DocumentAttributeValueChangedNotificationMatchInternal : DocumentNotificationMatchInternal
{
    public DocumentAttributeValueChangedNotificationMatchInternal(Id<DocumentAttributeInternal> attributeId)
    {
        AttributeId = attributeId;
    }

    public Id<DocumentAttributeInternal> AttributeId { get; }
}
