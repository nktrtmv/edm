namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;

public sealed class ReferenceAttributeDocumentStatusParameterBff : DocumentStatusParameterBff
{
    public required string ReferenceType { get; init; }
    public string[]? Values { get; init; } = [];
    public bool IsArray { get; init; }
}
