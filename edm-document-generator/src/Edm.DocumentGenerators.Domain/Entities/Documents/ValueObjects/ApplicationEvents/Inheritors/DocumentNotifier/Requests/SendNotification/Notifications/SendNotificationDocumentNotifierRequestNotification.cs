using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications;

public sealed class SendNotificationDocumentNotifierRequestNotification
{
    public SendNotificationDocumentNotifierRequestNotification(
        Id<NotificationTemplate> templateId,
        SendNotificationDocumentNotifierRequestNotificationParameter[] parameters)
    {
        TemplateId = templateId;
        Parameters = parameters;
    }

    public Id<NotificationTemplate> TemplateId { get; }
    public SendNotificationDocumentNotifierRequestNotificationParameter[] Parameters { get; }
}
