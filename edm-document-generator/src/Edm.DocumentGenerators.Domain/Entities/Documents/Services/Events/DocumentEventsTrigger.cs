using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Changed;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events;

internal static class DocumentEventsTrigger
{
    internal static void Trigger(DocumentUpdateParameters parameters, Document document, Id<User> currentUserId, IRoleAdapter roleAdapter)
    {
        Events<DocumentEventContext> events = DocumentEventsFactory.Create(document, currentUserId, roleAdapter);

        if (parameters.AttributesChange is not null)
        {
            DocumentAttributesValuesEventsTrigger.Trigger(events, parameters.AttributesChange);
        }

        if (parameters.StatusChange is not null)
        {
            DocumentStatusEventsTrigger.Trigger(events, parameters.StatusChange);
        }

        if (parameters.StatusChange is not null || parameters.AttributesChange is not null)
        {
            Trigger(events, parameters);
        }
    }

    private static void Trigger(Events<DocumentEventContext> events, DocumentUpdateParameters parameters)
    {
        var args = new DocumentChangedEventArgs(events.Context, parameters.StatusChange, parameters.AttributesChange);

        events.Trigger(args);
    }
}
