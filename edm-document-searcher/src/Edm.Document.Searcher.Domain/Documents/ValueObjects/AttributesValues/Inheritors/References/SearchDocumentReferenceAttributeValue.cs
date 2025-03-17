using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Abstractions;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;

public sealed class SearchDocumentReferenceAttributeValue(
    int registryRoleId,
    string[] values,
    string? referenceType,
    List<ParentReferenceTypeAttributeValue>? parentReferenceTypeAttributeValue = null)
    : SearchDocumentAttributeValueGeneric<string>(registryRoleId, values)
{
    public string? ReferenceType { get; } = referenceType;

    public List<ParentReferenceTypeAttributeValue>? ParentReferenceTypeAttributeValue { get; } = parentReferenceTypeAttributeValue;
}

public record ParentReferenceTypeAttributeValue(string ReferenceType, string[] Values);
