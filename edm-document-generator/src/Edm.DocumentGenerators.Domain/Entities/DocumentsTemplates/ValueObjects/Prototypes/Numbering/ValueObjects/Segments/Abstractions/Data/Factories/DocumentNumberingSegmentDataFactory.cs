using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data.Factories;

public static class DocumentNumberingSegmentDataFactory
{
    public static DocumentNumberingSegmentData Create(Id<DocumentNumberingSegment> id, string format)
    {
        var result = new DocumentNumberingSegmentData(id, format);

        return result;
    }
}
