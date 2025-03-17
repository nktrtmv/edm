using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.DocumentNotifier.Requests;

internal static class DocumentNotifierRequestsDocumentEventsHandlersFactory
{
    internal static EventsHandler[] Create(Document document)
    {
        EventsHandler[] result = document.Notifications
            .Select(Create)
            .ToArray();

        return result;
    }

    private static EventsHandler Create(DocumentNotification notification)
    {
        EventsHandler result = notification.Match switch
        {
            DocumentNotificationMatchGeneric<DocumentStatusChangedEventArgs> m =>
                new SendNotificationDocumentNotifierRequestDocumentStatusChangedDocumentNotifierRequestDocumentEventsHandler(m, notification),

            DocumentNotificationMatchGeneric<DocumentAttributeValueChangedEventArgs> m =>
                new SendNotificationDocumentNotifierRequestDocumentAttributeValueChangedDocumentNotifierRequestDocumentEventsHandler(m, notification),

            _ => throw new ArgumentTypeOutOfRangeException(notification.Match)
        };

        return result;
    }
}
