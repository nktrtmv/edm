using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;

internal static class GetDocumentCategoriesQueryInternalResponseConverter
{
    public static GetDocumentTypesQueryInternalResponse FromDomain(DocumentType[] types)
    {
        GetDocumentTypesQueryInternalResponseDocumentType[] typesInternal = types
            .Select(c => new GetDocumentTypesQueryInternalResponseDocumentType(c.Id.ToString(), c.Name, c.Description))
            .ToArray();

        var response = new GetDocumentTypesQueryInternalResponse(typesInternal);

        return response;
    }
}
