using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;

internal static class GetDocumentKindsQueryInternalResponseConverter
{
    public static GetDocumentKindsQueryInternalResponse FromDomain(DocumentKind[] documentsKinds)
    {
        GetDocumentKindsQueryInternalResponseDocumentKind[] documentsKindsInternal = documentsKinds
            .Select(k => new GetDocumentKindsQueryInternalResponseDocumentKind(k.Id.ToString(), k.Name, k.Description))
            .ToArray();

        var response = new GetDocumentKindsQueryInternalResponse(documentsKindsInternal);

        return response;
    }
}
