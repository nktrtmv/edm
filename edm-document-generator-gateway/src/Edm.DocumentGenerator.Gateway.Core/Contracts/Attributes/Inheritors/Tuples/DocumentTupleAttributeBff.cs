namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Tuples;

public sealed class DocumentTupleAttributeBff : DocumentAttributeBff
{
    public DocumentAttributeBff[] InnerAttributes { get; set; } = Array.Empty<DocumentAttributeBff>();
}
