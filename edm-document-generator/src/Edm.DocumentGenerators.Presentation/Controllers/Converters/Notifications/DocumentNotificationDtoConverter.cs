using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Markers;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Matches;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Parameters;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications;

internal static class DocumentNotificationDtoConverter
{
    internal static DocumentNotificationDto FromInternal(DocumentNotificationInternal notification)
    {
        var id = IdConverterTo.ToString(notification.Id);

        DocumentNotificationMatchDto match = DocumentNotificationMatchDtoConverter.FromInternal(notification.Match);

        var templateId = IdConverterTo.ToString(notification.TemplateId);

        DocumentNotificationParameterDto[] parameters = notification.Parameters.Select(DocumentNotificationParameterDtoConverter.FromInternal).ToArray();

        HashSet<string> recipientAttributeIds = notification.RecipientAttributeIds.Select(x => x.ToString()).ToHashSet();
        HashSet<string> recipientRoles = notification.RecipientRoles.Select(x => x.Value.ToString()).ToHashSet();

        var result = new DocumentNotificationDto
        {
            Id = id,
            Match = match,
            TemplateId = templateId,
            Parameters = { parameters },
            RecipientRoles = { recipientRoles },
            RecipientAttributeIds = { recipientAttributeIds }
        };

        return result;
    }

    internal static DocumentNotificationInternal ToInternal(DocumentNotificationDto notification)
    {
        Id<DocumentNotificationInternal> id =
            IdConverterFrom<DocumentNotificationInternal>.FromString(notification.Id);

        DocumentNotificationMatchInternal match =
            DocumentNotificationMatchDtoConverter.ToInternal(notification.Match);

        Id<NotificationTemplateInternal> templateId =
            IdConverterFrom<NotificationTemplateInternal>.FromString(notification.TemplateId);

        DocumentNotificationParameterInternal[] parameters =
            notification.Parameters.Select(DocumentNotificationParameterDtoConverter.ToInternal).ToArray();

#pragma warning disable CS0612 // Type or member is obsolete

        Id<DocumentAttributeInternal>[] recipientAttributeIds = notification.RecipientAttributeIds
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(IdConverterFrom<DocumentAttributeInternal>.FromString)
            .ToArray();

#pragma warning restore CS0612 // Type or member is obsolete

        Role[] recipientRoles = notification.RecipientRoles.Select(x => new Role(x)).ToArray();
        var result = new DocumentNotificationInternal(id, match, templateId, parameters, recipientAttributeIds, recipientRoles);

        return result;
    }
}
