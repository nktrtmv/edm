using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering;

public sealed class DocumentNumbering
{
    internal DocumentNumbering(DocumentNumberingSegment[] segments)
    {
        Segments = segments;
    }

    public DocumentNumberingSegment[] Segments { get; }
}
