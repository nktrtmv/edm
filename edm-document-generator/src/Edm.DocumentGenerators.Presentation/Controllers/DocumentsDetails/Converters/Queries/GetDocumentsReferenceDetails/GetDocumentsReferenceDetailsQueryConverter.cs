using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsReferenceDetails;

internal static class GetDocumentsReferenceDetailsQueryConverter
{
    internal static GetDocumentsReferenceDetailsQueryInternal ToInternal(GetDocumentsReferenceDetailsQuery query)
    {
        Id<DocumentInternal>[] documentsIds = query.DocumentsIds.Select(IdConverterFrom<DocumentInternal>.FromString).ToArray();

        var result = new GetDocumentsReferenceDetailsQueryInternal(documentsIds);

        return result;
    }
}
