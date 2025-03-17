using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.DocumentNotifier.Requests.SendNotification;

internal sealed class SendNotificationDocumentNotifierRequestDocumentStatusChangedDocumentNotifierRequestDocumentEventsHandler
    : SendNotificationDocumentNotifierRequestDocumentEventsHandler<DocumentStatusChangedEventArgs>
{
    public SendNotificationDocumentNotifierRequestDocumentStatusChangedDocumentNotifierRequestDocumentEventsHandler(
        DocumentNotificationMatchGeneric<DocumentStatusChangedEventArgs> match,
        DocumentNotification notification)
        : base(match, notification)
    {
    }
}
