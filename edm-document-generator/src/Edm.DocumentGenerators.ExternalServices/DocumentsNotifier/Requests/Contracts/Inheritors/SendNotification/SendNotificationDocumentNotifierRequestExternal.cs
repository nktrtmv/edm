using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts.Inheritors.SendNotification;

public sealed class SendNotificationDocumentNotifierRequestExternal : DocumentNotifierRequestExternal
{
    public SendNotificationDocumentNotifierRequestExternal(
        Document document,
        SendNotificationDocumentNotifierRequestNotification notification,
        Id<User> currentUserId,
        HashSet<Id<User>> recipientIds,
        HashSet<Role> recipientRoles)
        : base(document)
    {
        Notification = notification;
        CurrentUserId = currentUserId;
        RecipientIds = recipientIds;
        RecipientRoles = recipientRoles;
    }

    public SendNotificationDocumentNotifierRequestNotification Notification { get; }
    public Id<User> CurrentUserId { get; }

    public HashSet<Id<User>> RecipientIds { get; }
    public HashSet<Role> RecipientRoles { get; }
}
