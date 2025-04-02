namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Numbers;

public sealed class DocumentNumberAttributeBff : DocumentAttributeBff
{
    public long[] DefaultValues { get; set; } = [];
    public int Precision { get; init; }
}
