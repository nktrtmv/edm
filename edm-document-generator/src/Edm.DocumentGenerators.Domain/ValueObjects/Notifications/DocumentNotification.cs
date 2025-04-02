using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Notifications;

public sealed class DocumentNotification
{
    public DocumentNotification(
        Id<DocumentNotification> id,
        DocumentNotificationMatch match,
        Id<NotificationTemplate> templateId,
        DocumentNotificationParameter[] parameters,
        HashSet<Id<DocumentAttribute>> recipientAttributeIds,
        HashSet<Role> recipientRoles)
    {
        Id = id;
        Match = match;
        TemplateId = templateId;
        Parameters = parameters;
        RecipientAttributeIds = recipientAttributeIds;
        RecipientRoles = recipientRoles;
    }

    public Id<DocumentNotification> Id { get; }
    public DocumentNotificationMatch Match { get; }
    public Id<NotificationTemplate> TemplateId { get; }
    public DocumentNotificationParameter[] Parameters { get; }
    public HashSet<Id<DocumentAttribute>> RecipientAttributeIds { get; }
    public HashSet<Role> RecipientRoles { get; }
}
