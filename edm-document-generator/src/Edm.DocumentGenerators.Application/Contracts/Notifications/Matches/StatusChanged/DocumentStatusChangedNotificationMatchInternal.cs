using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.StatusChanged;

public sealed class DocumentStatusChangedNotificationMatchInternal : DocumentNotificationMatchInternal
{
    public DocumentStatusChangedNotificationMatchInternal(Id<DocumentStatusInternal> statusFromId, Id<DocumentStatusInternal> statusToId)
    {
        StatusFromId = statusFromId;
        StatusToId = statusToId;
    }

    public Id<DocumentStatusInternal> StatusFromId { get; }
    public Id<DocumentStatusInternal> StatusToId { get; }
}
