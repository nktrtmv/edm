using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentKinds;

internal static class GetDocumentKindsQueryResponseConverter
{
    internal static GetDocumentKindsQueryResponse FromInternal(GetDocumentKindsQueryInternalResponse response)
    {
        GetDocumentKindsQueryResponseDocumentKind[] documentKinds = response.DocumentKinds.Select(
                b => new GetDocumentKindsQueryResponseDocumentKind
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                })
            .ToArray();

        var result = new GetDocumentKindsQueryResponse
        {
            DocumentKinds = { documentKinds }
        };

        return result;
    }
}
