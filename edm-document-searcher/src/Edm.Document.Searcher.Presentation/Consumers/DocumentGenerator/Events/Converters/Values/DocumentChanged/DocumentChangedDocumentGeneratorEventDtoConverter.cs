using Edm.Document.Searcher.Application.Documents.Events.DocumentGenerators.DocumentChanged.Contracts;
using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Consumers.DocumentGenerator.Events.Converters.Values.DocumentChanged;

internal static class DocumentChangedDocumentGeneratorEventDtoConverter
{
    internal static DocumentChangedDocumentGeneratorEventInternal ToInternal(DocumentChangedDocumentGeneratorEventDto documentChanged)
    {
        var documentId = IdConverterFrom<SearchDocumentInternal>.FromString(documentChanged.DocumentId);

        var result = new DocumentChangedDocumentGeneratorEventInternal(documentChanged.DomainId, documentId);

        return result;
    }
}
