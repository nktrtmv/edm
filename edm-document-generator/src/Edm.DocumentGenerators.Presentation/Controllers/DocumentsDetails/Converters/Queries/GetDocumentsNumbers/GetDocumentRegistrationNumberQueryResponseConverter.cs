using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsNumbers.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsNumbers;

internal static class GetDocumentRegistrationNumberQueryResponseConverter
{
    internal static GetDocumentRegistrationNumberQueryResponse FromInternal(GetDocumentRegistrationNumberQueryInternalResponse response)
    {
        var result = new GetDocumentRegistrationNumberQueryResponse
        {
            RegistrationNumber = response.RegistrationNumber
        };

        return result;
    }
}
