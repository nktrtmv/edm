namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Dates;

public sealed class DocumentDateAttributeBff : DocumentAttributeBff
{
    public DateTime[] DefaultValues { get; set; } = [];
}
