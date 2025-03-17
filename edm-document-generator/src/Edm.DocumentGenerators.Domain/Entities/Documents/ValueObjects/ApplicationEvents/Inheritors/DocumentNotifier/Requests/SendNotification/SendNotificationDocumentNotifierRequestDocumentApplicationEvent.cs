using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification;

public sealed record SendNotificationDocumentNotifierRequestDocumentApplicationEvent(
    SendNotificationDocumentNotifierRequestNotification Notification,
    Id<User> CurrentUserId,
    HashSet<Id<User>> RecipientIds,
    HashSet<Role> RecipientRoles)
    : DocumentNotifierRequestDocumentApplicationEvent
{
    public HashSet<Role> RecipientRoles { get; set; } = RecipientRoles;
}
