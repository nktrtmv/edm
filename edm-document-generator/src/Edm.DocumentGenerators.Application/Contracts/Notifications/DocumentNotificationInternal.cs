using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Markers;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications;

public sealed class DocumentNotificationInternal
{
    public DocumentNotificationInternal(
        Id<DocumentNotificationInternal> id,
        DocumentNotificationMatchInternal match,
        Id<NotificationTemplateInternal> templateId,
        DocumentNotificationParameterInternal[] parameters,
        Id<DocumentAttributeInternal>[] recipientAttributeIds,
        Role[] recipientRoles)
    {
        Id = id;
        Match = match;
        TemplateId = templateId;
        Parameters = parameters;
        RecipientAttributeIds = recipientAttributeIds;
        RecipientRoles = recipientRoles;
    }

    public Id<DocumentNotificationInternal> Id { get; }
    public DocumentNotificationMatchInternal Match { get; }
    public Id<NotificationTemplateInternal> TemplateId { get; }
    public DocumentNotificationParameterInternal[] Parameters { get; }

    public Id<DocumentAttributeInternal>[] RecipientAttributeIds { get; }

    public Role[] RecipientRoles { get; }
}
