namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.ReferenceAttributes;

public sealed class ReferenceAttributeDocumentStatusParameterExternal : DocumentStatusParameterExternal
{
    public required string ReferenceType { get; init; }
    public string[] Values { get; init; } = [];
    public bool IsArray { get; init; }
}
