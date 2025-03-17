namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;

public sealed class ReferenceAttributeDocumentStatusParameterInternal : DocumentStatusParameterInternal
{
    public required string ReferenceType { get; init; }
    public string[]? Values { get; init; } = [];
    public bool IsArray { get; init; }
}
