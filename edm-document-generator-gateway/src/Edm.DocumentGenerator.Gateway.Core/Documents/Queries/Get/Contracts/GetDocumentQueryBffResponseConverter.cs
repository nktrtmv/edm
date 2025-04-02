using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts;

internal static class GetDocumentQueryBffResponseConverter
{
    internal static GetDocumentQueryBffResponse FromInternal(DocumentDetailedBff document)
    {
        var result = new GetDocumentQueryBffResponse
        {
            Document = document
        };

        return result;
    }
}
