namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

public sealed class DocumentNumberingSegmentDataInternal
{
    public DocumentNumberingSegmentDataInternal(string id, string format)
    {
        Id = id;
        Format = format;
    }

    public string Id { get; }
    public string Format { get; }
}
