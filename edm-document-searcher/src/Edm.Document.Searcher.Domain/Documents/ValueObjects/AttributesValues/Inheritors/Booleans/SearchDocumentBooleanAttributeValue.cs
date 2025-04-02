using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Abstractions;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Booleans;

public sealed class SearchDocumentBooleanAttributeValue : SearchDocumentAttributeValueGeneric<bool>
{
    public SearchDocumentBooleanAttributeValue(int registryRoleId, bool[] values) : base(registryRoleId, values)
    {
    }
}
