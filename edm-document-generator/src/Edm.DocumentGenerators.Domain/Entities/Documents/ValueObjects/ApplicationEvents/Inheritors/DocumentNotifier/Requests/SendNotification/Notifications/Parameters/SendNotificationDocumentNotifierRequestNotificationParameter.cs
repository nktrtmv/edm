using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;

public sealed class SendNotificationDocumentNotifierRequestNotificationParameter
{
    public SendNotificationDocumentNotifierRequestNotificationParameter(Id<NotificationTemplateParameter> id, DocumentAttributeValue value)
    {
        Id = id;
        Value = value;
    }

    public Id<NotificationTemplateParameter> Id { get; }
    public DocumentAttributeValue Value { get; }
}
