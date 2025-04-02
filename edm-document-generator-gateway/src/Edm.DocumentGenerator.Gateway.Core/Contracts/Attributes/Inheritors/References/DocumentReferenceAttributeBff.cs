namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.References;

public sealed class DocumentReferenceAttributeBff : DocumentAttributeBff
{
    public string[] DefaultValues { get; set; } = [];
    public string ReferenceType { get; init; } = string.Empty;
}
