using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts;

internal static class GetDocumentQueryBffConverter
{
    internal static GetDocumentQuery ToDto(GetDocumentQueryBff query)
    {
        var result = new GetDocumentQuery
        {
            DocumentId = query.Id,
            SkipProcessing = query.SkipProcessing
        };

        return result;
    }
}
