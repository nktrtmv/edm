using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.AttributesValues;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests.SendNotification.Notifications.
    Parameters;

internal static class SendNotificationDocumentNotifierRequestNotificationParameterDbConverter
{
    internal static SendNotificationDocumentNotifierRequestNotificationParameterDb FromDomain(SendNotificationDocumentNotifierRequestNotificationParameter parameter)
    {
        var id = IdConverterTo.ToString(parameter.Id);

        DocumentAttributeValueDb value = DocumentAttributeValueDbFromDomainConverter.FromDomain(parameter.Value);

        var result = new SendNotificationDocumentNotifierRequestNotificationParameterDb
        {
            Id = id,
            Value = value
        };

        return result;
    }

    internal static SendNotificationDocumentNotifierRequestNotificationParameter ToDomain(SendNotificationDocumentNotifierRequestNotificationParameterDb parameter)
    {
        Id<NotificationTemplateParameter> id = IdConverterFrom<NotificationTemplateParameter>.FromString(parameter.Id);

        DocumentAttributeValue value = DocumentAttributeValueDbToDomainConverter.ToDomain(parameter.Value);

        var result = new SendNotificationDocumentNotifierRequestNotificationParameter(id, value);

        return result;
    }
}
