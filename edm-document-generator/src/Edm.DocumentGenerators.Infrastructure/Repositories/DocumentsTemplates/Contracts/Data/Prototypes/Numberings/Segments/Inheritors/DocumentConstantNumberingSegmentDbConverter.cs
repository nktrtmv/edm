using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments.Inheritors;

public static class DocumentConstantNumberingSegmentDbConverter
{
    internal static DocumentNumberingSegmentDb FromDomain(DocumentNumberingSegmentDataDb data, DocumentConstantNumberingSegment segment)
    {
        var result = new DocumentNumberingSegmentDb
        {
            AsConstant = new DocumentConstantNumberingSegmentDb
            {
                Value = segment.Value
            },
            Data = data
        };

        return result;
    }

    internal static DocumentNumberingSegment ToDomain(DocumentNumberingSegmentData data, DocumentConstantNumberingSegmentDb segment)
    {
        var result = new DocumentConstantNumberingSegment(data, segment.Value);

        return result;
    }
}
