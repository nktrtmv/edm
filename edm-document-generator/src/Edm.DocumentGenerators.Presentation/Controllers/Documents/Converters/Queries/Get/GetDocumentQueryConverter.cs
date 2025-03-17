using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get;

internal static class GetDocumentQueryConverter
{
    internal static GetDocumentQueryInternal ToInternal(GetDocumentQuery query)
    {
        Id<DocumentInternal> documentId = IdConverterFrom<DocumentInternal>.FromString(query.DocumentId);

        var result = new GetDocumentQueryInternal(documentId, query.SkipProcessing);

        return result;
    }
}
