namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;

public sealed class DocumentCounterNumberingSegmentBff : DocumentNumberingSegmentBff
{
    public required string CounterId { get; init; }
}
