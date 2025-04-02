using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.StatusChanged;

public sealed class DocumentStatusChangedNotificationMatch : DocumentNotificationMatchGeneric<DocumentStatusChangedEventArgs>
{
    public DocumentStatusChangedNotificationMatch(Id<DocumentStatus> statusFromId, Id<DocumentStatus> statusToId)
    {
        StatusFromId = statusFromId;
        StatusToId = statusToId;
    }

    public Id<DocumentStatus> StatusFromId { get; }
    public Id<DocumentStatus> StatusToId { get; }

    public override bool IsMatched(DocumentStatusChangedEventArgs args)
    {
        bool result =
            args.Change.Transition.From.Id == StatusFromId &&
            args.Change.Transition.To.Id == StatusToId;

        return result;
    }
}
