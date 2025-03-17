using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests.SendNotification.Notifications;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests.SendNotification;

internal static class SendNotificationDocumentNotifierRequestDbConverter
{
    internal static SendNotificationDocumentNotifierRequestDb FromDomain(SendNotificationDocumentNotifierRequestDocumentApplicationEvent applicationEvent)
    {
        SendNotificationDocumentNotifierRequestNotificationDb notification =
            SendNotificationDocumentNotifierRequestNotificationDbConverter.FromDomain(applicationEvent.Notification);

        var currentUserId = IdConverterTo.ToString(applicationEvent.CurrentUserId);

        var result = new SendNotificationDocumentNotifierRequestDb
        {
            Notification = notification,
            CurrentUserId = currentUserId,
            RecipientIds = { applicationEvent.RecipientIds.Select(x => x.ToString()) },
            RecipientRoles = { applicationEvent.RecipientRoles.Select(x => x.Value) }
        };

        return result;
    }

    internal static SendNotificationDocumentNotifierRequestDocumentApplicationEvent ToDomain(SendNotificationDocumentNotifierRequestDb applicationEvent)
    {
        SendNotificationDocumentNotifierRequestNotification notification =
            SendNotificationDocumentNotifierRequestNotificationDbConverter.ToDomain(applicationEvent.Notification);

        Id<User> currentUserId = IdConverterFrom<User>.FromString(applicationEvent.CurrentUserId);

#pragma warning disable CS0612 // Type or member is obsolete
        HashSet<Id<User>> recipientIds = applicationEvent.RecipientIds.Concat([applicationEvent.RecipientId])
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(IdConverterFrom<User>.FromString)
            .ToHashSet();
#pragma warning restore CS0612 // Type or member is obsolete

        HashSet<Role> recipientRoles = applicationEvent.RecipientRoles.Select(x => new Role(x)).ToHashSet();
        var result = new SendNotificationDocumentNotifierRequestDocumentApplicationEvent(notification, currentUserId, recipientIds, recipientRoles);

        return result;
    }
}
