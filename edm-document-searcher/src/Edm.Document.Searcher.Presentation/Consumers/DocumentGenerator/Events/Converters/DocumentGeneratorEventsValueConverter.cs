using Edm.Document.Searcher.Presentation.Consumers.DocumentGenerator.Events.Converters.Values.DocumentChanged;
using Edm.DocumentGenerators.Presentation.Abstractions;

using MediatR;

namespace Edm.Document.Searcher.Presentation.Consumers.DocumentGenerator.Events.Converters;

internal static class DocumentGeneratorEventsValueConverter
{
    internal static IRequest? ToInternal(DocumentGeneratorEventsValue value)
    {
        IRequest? result = value.EventCase switch
        {
            DocumentGeneratorEventsValue.EventOneofCase.AsDocumentChanged =>
                DocumentChangedDocumentGeneratorEventDtoConverter.ToInternal(value.AsDocumentChanged),

            _ => null
        };

        return result;
    }
}
