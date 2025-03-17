using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentTypes;

internal static class GetDocumentTypesQueryResponseConverter
{
    internal static GetDocumentTypesQueryResponse FromInternal(GetDocumentTypesQueryInternalResponse internalResponse)
    {
        GetDocumentTypesQueryResponseDocumentType[] documentTypes = internalResponse.DocumentTypes.Select(
                b => new GetDocumentTypesQueryResponseDocumentType
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                })
            .ToArray();

        var response = new GetDocumentTypesQueryResponse
        {
            DocumentTypes = { documentTypes }
        };

        return response;
    }
}
