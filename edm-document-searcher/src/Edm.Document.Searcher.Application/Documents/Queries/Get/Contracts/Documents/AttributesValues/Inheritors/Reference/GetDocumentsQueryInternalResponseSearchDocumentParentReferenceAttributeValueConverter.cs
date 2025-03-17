using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Reference;

public sealed record GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValueConverter
{
    public static GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValue FromDomain(ParentReferenceTypeAttributeValue model)
    {
        var result = new GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValue(model.ReferenceType, model.Values);

        return result;
    }

    public static ParentReferenceTypeAttributeValue FromDomain(GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValue model)
    {
        var result = new ParentReferenceTypeAttributeValue(model.ReferenceType, model.Values);

        return result;
    }
}
