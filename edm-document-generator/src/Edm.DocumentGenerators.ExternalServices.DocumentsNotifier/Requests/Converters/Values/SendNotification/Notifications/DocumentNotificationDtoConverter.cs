using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Documents.Notifiers.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values.SendNotification.Notifications;

internal static class DocumentNotificationDtoConverter
{
    internal static DocumentNotificationDto FromDomain(SendNotificationDocumentNotifierRequestNotification notification)
    {
        var templateId = IdConverterTo.ToString(notification.TemplateId);

        DocumentNotificationParameterDto[] parameters =
            notification.Parameters.Select(DocumentNotificationParameterDtoConverter.FromDomain).ToArray();

        var result = new DocumentNotificationDto
        {
            TemplateId = templateId,
            Parameters = { parameters }
        };

        return result;
    }
}
