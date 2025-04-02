using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsNumbers.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsNumbers;

internal static class GetDocumentRegistrationNumberQueryConverter
{
    internal static GetDocumentRegistrationNumberQueryInternal ToInternal(GetDocumentRegistrationNumberQuery query)
    {
        Id<DocumentInternal> documentId = IdConverterFrom<DocumentInternal>.FromString(query.DocumentId);

        var result = new GetDocumentRegistrationNumberQueryInternal(documentId);

        return result;
    }
}
