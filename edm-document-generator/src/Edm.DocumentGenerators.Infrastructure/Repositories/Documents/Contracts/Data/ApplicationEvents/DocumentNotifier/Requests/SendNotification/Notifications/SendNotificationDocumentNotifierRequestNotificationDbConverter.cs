using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests.SendNotification.Notifications;

internal static class SendNotificationDocumentNotifierRequestNotificationDbConverter
{
    internal static SendNotificationDocumentNotifierRequestNotificationDb FromDomain(SendNotificationDocumentNotifierRequestNotification notification)
    {
        var templateId = IdConverterTo.ToString(notification.TemplateId);

        SendNotificationDocumentNotifierRequestNotificationParameterDb[] parameters =
            notification.Parameters.Select(SendNotificationDocumentNotifierRequestNotificationParameterDbConverter.FromDomain).ToArray();

        var result = new SendNotificationDocumentNotifierRequestNotificationDb
        {
            TemplateId = templateId,
            Parameters = { parameters }
        };

        return result;
    }

    internal static SendNotificationDocumentNotifierRequestNotification ToDomain(SendNotificationDocumentNotifierRequestNotificationDb notification)
    {
        Id<NotificationTemplate> templateId = IdConverterFrom<NotificationTemplate>.FromString(notification.TemplateId);

        SendNotificationDocumentNotifierRequestNotificationParameter[] parameters =
            notification.Parameters.Select(SendNotificationDocumentNotifierRequestNotificationParameterDbConverter.ToDomain).ToArray();

        var result = new SendNotificationDocumentNotifierRequestNotification(templateId, parameters);

        return result;
    }
}
