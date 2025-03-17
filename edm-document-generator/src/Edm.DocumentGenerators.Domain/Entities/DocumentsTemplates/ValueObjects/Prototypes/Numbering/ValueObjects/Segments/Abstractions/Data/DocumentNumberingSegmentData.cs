using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

public sealed class DocumentNumberingSegmentData
{
    internal DocumentNumberingSegmentData(Id<DocumentNumberingSegment> id, string format)
    {
        Id = id;
        Format = format;
    }

    public Id<DocumentNumberingSegment> Id { get; }
    public string Format { get; }
}
