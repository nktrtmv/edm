using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsReferenceDetails.Contracts.DocumentsReferenceDetails;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsReferenceDetails;

internal static class GetDocumentsReferenceDetailsQueryResponseConverter
{
    internal static GetDocumentsReferenceDetailsQueryResponse FromInternal(GetDocumentsReferenceDetailsQueryInternalResponse response)
    {
        DocumentReferenceDetailsDto[] details = response.Details.Select(DocumentReferenceDetailsDtoConverter.FromInternal).ToArray();

        var result = new GetDocumentsReferenceDetailsQueryResponse
        {
            Details = { details }
        };

        return result;
    }
}
