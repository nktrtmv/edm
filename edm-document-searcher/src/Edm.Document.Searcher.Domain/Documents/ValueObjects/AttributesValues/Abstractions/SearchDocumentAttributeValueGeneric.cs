using System.Diagnostics;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Abstractions;

[DebuggerDisplay("{ToDebugDisplay}")]
public abstract class SearchDocumentAttributeValueGeneric<T>(int registryRoleId, T[] values) : SearchDocumentAttributeValue(registryRoleId)
{
    public T[] Values { get; } = values;

    private string ToDebugDisplay => $"Role: {RegistryRoleId}. Values: {(Values.Length > 0 ? "[" + string.Join(", ", Values) + "]" : '-')}";
}
