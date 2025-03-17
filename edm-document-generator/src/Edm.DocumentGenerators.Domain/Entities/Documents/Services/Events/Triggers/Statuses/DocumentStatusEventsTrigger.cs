using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses;

internal static class DocumentStatusEventsTrigger
{
    internal static void Trigger(Events<DocumentEventContext> events, DocumentStatusChange statusChange)
    {
        TriggerStatusChangedEvent(events, statusChange);
    }

    private static void TriggerStatusChangedEvent(Events<DocumentEventContext> events, DocumentStatusChange change)
    {
        var args = new DocumentStatusChangedEventArgs(events.Context, change);

        events.Trigger(args);
    }
}
