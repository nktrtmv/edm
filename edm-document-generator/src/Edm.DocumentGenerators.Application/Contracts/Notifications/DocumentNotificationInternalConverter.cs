using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Markers;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications;

internal static class DocumentNotificationInternalConverter
{
    internal static DocumentNotificationInternal FromDomain(DocumentNotification notification)
    {
        Id<DocumentNotificationInternal> id =
            IdConverterFrom<DocumentNotificationInternal>.From(notification.Id);

        DocumentNotificationMatchInternal match =
            DocumentNotificationMatchInternalConverter.FromDomain(notification.Match);

        Id<NotificationTemplateInternal> templateId =
            IdConverterFrom<NotificationTemplateInternal>.From(notification.TemplateId);

        DocumentNotificationParameterInternal[] parameters =
            notification.Parameters.Select(DocumentNotificationParameterInternalConverter.FromDomain).ToArray();

        Id<DocumentAttributeInternal>[] recipientAttributesIds =
            notification.RecipientAttributeIds.Select(IdConverterFrom<DocumentAttributeInternal>.From).ToArray();

        var result = new DocumentNotificationInternal(id, match, templateId, parameters, recipientAttributesIds, notification.RecipientRoles.ToArray());

        return result;
    }

    internal static DocumentNotification ToDomain(DocumentNotificationInternal notification)
    {
        Id<DocumentNotification> id =
            IdConverterFrom<DocumentNotification>.From(notification.Id);

        DocumentNotificationMatch match =
            DocumentNotificationMatchInternalConverter.ToDomain(notification.Match);

        Id<NotificationTemplate> templateId = IdConverterFrom<NotificationTemplate>.From(notification.TemplateId);

        DocumentNotificationParameter[] parameters =
            notification.Parameters.Select(DocumentNotificationParameterInternalConverter.ToDomain).ToArray();

        HashSet<Id<DocumentAttribute>> recipientAttributesIds =
            notification.RecipientAttributeIds.Select(IdConverterFrom<DocumentAttribute>.From).ToHashSet();

        var result = new DocumentNotification(id, match, templateId, parameters, recipientAttributesIds, notification.RecipientRoles.ToHashSet());

        return result;
    }
}
