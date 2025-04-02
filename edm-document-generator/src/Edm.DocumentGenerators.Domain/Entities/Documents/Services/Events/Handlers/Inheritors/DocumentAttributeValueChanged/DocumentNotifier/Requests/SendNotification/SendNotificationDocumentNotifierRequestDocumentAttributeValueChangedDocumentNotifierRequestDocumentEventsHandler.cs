using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.DocumentNotifier.Requests.SendNotification;

internal sealed class SendNotificationDocumentNotifierRequestDocumentAttributeValueChangedDocumentNotifierRequestDocumentEventsHandler
    : SendNotificationDocumentNotifierRequestDocumentEventsHandler<DocumentAttributeValueChangedEventArgs>
{
    public SendNotificationDocumentNotifierRequestDocumentAttributeValueChangedDocumentNotifierRequestDocumentEventsHandler(
        DocumentNotificationMatchGeneric<DocumentAttributeValueChangedEventArgs> match,
        DocumentNotification notification)
        : base(match, notification)
    {
    }
}
