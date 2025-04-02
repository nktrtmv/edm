using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;

public abstract class DocumentNumberingSegment
{
    protected DocumentNumberingSegment(DocumentNumberingSegmentData data)
    {
        Data = data;
    }

    public DocumentNumberingSegmentData Data { get; }
}
