namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;

public sealed class DocumentConstantNumberingSegmentBff : DocumentNumberingSegmentBff
{
    public required string Value { get; init; }
}
