using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentGenerator.Events.
    DocumentChanged;

internal abstract class DocumentChangedDocumentGeneratorEventDocumentEventsHandler<TEventArgs> : EventsHandlerGeneric<TEventArgs>
    where TEventArgs : DocumentEventArgs<DocumentEventContext>
{
    public override void Handle(TEventArgs args)
    {
        Document document = args.Context.Host;

        var documentChanged = new DocumentChangedDocumentGeneratorEventDocumentApplicationEvent();

        document.ApplicationEvents.Add(documentChanged);
    }
}
