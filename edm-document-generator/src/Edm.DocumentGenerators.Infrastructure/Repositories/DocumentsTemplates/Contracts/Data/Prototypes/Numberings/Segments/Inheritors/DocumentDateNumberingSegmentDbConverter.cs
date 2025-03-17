using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments.Inheritors;

public static class DocumentDateNumberingSegmentDbConverter
{
    internal static DocumentNumberingSegmentDb FromDomain(DocumentNumberingSegmentDataDb data)
    {
        var result = new DocumentNumberingSegmentDb
        {
            AsDate = new DocumentDateNumberingSegmentDb(),
            Data = data
        };

        return result;
    }

    internal static DocumentDateNumberingSegment ToDomain(DocumentNumberingSegmentData data)
    {
        var result = new DocumentDateNumberingSegment(data);

        return result;
    }
}
