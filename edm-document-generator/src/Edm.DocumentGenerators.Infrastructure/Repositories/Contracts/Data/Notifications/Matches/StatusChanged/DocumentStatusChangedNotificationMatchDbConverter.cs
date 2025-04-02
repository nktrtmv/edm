using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Matches.StatusChanged;

internal static class DocumentStatusChangedNotificationMatchDbConverter
{
    internal static DocumentNotificationMatchDb FromDomain(DocumentStatusChangedNotificationMatch match)
    {
        var statusFromId = IdConverterTo.ToString(match.StatusFromId);

        var statusToId = IdConverterTo.ToString(match.StatusToId);

        var result = new DocumentNotificationMatchDb
        {
            AsStatusChanged = new DocumentStatusChangedNotificationMatchDb
            {
                StatusFromId = statusFromId,
                StatusToId = statusToId
            }
        };

        return result;
    }

    internal static DocumentNotificationMatch ToDomain(DocumentStatusChangedNotificationMatchDb match)
    {
        Id<DocumentStatus> statusFromId = IdConverterFrom<DocumentStatus>.FromString(match.StatusFromId);

        Id<DocumentStatus> statusToId = IdConverterFrom<DocumentStatus>.FromString(match.StatusToId);

        var result = new DocumentStatusChangedNotificationMatch(statusFromId, statusToId);

        return result;
    }
}
