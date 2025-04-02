using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.StatusChanged;

internal static class DocumentStatusChangedNotificationMatchInternalConverter
{
    internal static DocumentNotificationMatchInternal FromDomain(DocumentStatusChangedNotificationMatch match)
    {
        Id<DocumentStatusInternal> statusFromId = IdConverterFrom<DocumentStatusInternal>.From(match.StatusFromId);

        Id<DocumentStatusInternal> statusToId = IdConverterFrom<DocumentStatusInternal>.From(match.StatusToId);

        var result = new DocumentStatusChangedNotificationMatchInternal(statusFromId, statusToId);

        return result;
    }

    internal static DocumentNotificationMatch ToDomain(DocumentStatusChangedNotificationMatchInternal match)
    {
        Id<DocumentStatus> statusFromId = IdConverterFrom<DocumentStatus>.From(match.StatusFromId);

        Id<DocumentStatus> statusToId = IdConverterFrom<DocumentStatus>.From(match.StatusToId);

        var result = new DocumentStatusChangedNotificationMatch(statusFromId, statusToId);

        return result;
    }
}
