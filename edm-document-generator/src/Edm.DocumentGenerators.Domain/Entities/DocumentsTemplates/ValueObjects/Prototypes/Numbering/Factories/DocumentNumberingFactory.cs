using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.Factories;

public static class DocumentNumberingFactory
{
    public static DocumentNumbering CreateNew()
    {
        DocumentNumberingSegment[] segments = Array.Empty<DocumentNumberingSegment>();

        DocumentNumbering result = CreateFrom(segments);

        return result;
    }

    public static DocumentNumbering CreateFrom(DocumentNumberingSegment[] segments)
    {
        DocumentNumbering result = CreateFromDb(segments);

        return result;
    }

    public static DocumentNumbering CreateFromDb(DocumentNumberingSegment[] segments)
    {
        var result = new DocumentNumbering(segments);

        return result;
    }
}
