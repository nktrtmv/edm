using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.References;

internal sealed class SearchDocumentParentReferenceAttributeValueDbConverter
{
    internal static SearchDocumentParentReferenceAttributeValueDb FromDomain(ParentReferenceTypeAttributeValue model)
    {
        var result = new SearchDocumentParentReferenceAttributeValueDb(model.ReferenceType, model.Values);

        return result;
    }

    internal static ParentReferenceTypeAttributeValue ToDomain(SearchDocumentParentReferenceAttributeValueDb model)
    {
        var result = new ParentReferenceTypeAttributeValue(model.ReferenceType, model.Values);

        return result;
    }
}
