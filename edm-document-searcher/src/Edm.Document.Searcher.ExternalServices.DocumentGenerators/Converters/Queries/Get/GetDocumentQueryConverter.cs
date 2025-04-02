using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get;

internal static class GetDocumentQueryConverter
{
    private const bool SkipProcessing = true;

    internal static GetDocumentQuery FromExternal(Id<DocumentExternal> id)
    {
        var documentId = IdConverterTo.ToString(id);

        var result = new GetDocumentQuery
        {
            DocumentId = documentId,
            SkipProcessing = SkipProcessing
        };

        return result;
    }
}
