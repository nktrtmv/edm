using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributesValuesChanged;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributesValuesChanged.DocumentGenerator.Events.DocumentChanged;

internal sealed class DocumentChangedDocumentGeneratorEventDocumentAttributesValuesChangedDocumentEventsHandler
    : DocumentChangedDocumentGeneratorEventDocumentEventsHandler<DocumentAttributesValuesChangedEventArgs>
{
}
