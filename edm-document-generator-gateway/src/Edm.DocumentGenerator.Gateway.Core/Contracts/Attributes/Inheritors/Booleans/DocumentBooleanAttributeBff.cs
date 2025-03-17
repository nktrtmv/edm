namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Booleans;

public sealed class DocumentBooleanAttributeBff : DocumentAttributeBff
{
    public bool[] DefaultValues { get; set; } = [];
}
