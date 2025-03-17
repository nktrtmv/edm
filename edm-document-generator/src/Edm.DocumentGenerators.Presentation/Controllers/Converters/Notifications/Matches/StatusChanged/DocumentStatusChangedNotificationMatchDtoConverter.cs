using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Matches.StatusChanged;

internal static class DocumentStatusChangedNotificationMatchDtoConverter
{
    internal static DocumentNotificationMatchDto FromInternal(DocumentStatusChangedNotificationMatchInternal match)
    {
        var statusFromId = IdConverterTo.ToString(match.StatusFromId);

        var statusToId = IdConverterTo.ToString(match.StatusToId);

        var result = new DocumentNotificationMatchDto
        {
            AsStatusChanged = new DocumentStatusChangedNotificationMatchDto
            {
                StatusFromId = statusFromId,
                StatusToId = statusToId
            }
        };

        return result;
    }

    internal static DocumentNotificationMatchInternal ToInternal(DocumentStatusChangedNotificationMatchDto match)
    {
        Id<DocumentStatusInternal> statusFromId = IdConverterFrom<DocumentStatusInternal>.FromString(match.StatusFromId);

        Id<DocumentStatusInternal> statusToId = IdConverterFrom<DocumentStatusInternal>.FromString(match.StatusToId);

        var result = new DocumentStatusChangedNotificationMatchInternal(statusFromId, statusToId);

        return result;
    }
}
