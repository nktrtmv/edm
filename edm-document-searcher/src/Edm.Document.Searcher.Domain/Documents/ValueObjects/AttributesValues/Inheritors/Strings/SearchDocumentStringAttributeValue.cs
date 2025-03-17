using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Abstractions;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Strings;

public sealed class SearchDocumentStringAttributeValue : SearchDocumentAttributeValueGeneric<string>
{
    public SearchDocumentStringAttributeValue(int registryRoleId, params string[] values) : base(registryRoleId, values)
    {
    }
}
