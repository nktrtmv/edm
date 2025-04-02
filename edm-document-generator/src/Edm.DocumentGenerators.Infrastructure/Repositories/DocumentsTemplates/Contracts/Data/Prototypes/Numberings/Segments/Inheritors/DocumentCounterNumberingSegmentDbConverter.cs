using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments.Inheritors;

public static class DocumentCounterNumberingSegmentDbConverter
{
    internal static DocumentNumberingSegmentDb FromDomain(DocumentNumberingSegmentDataDb data, DocumentCounterNumberingSegment segment)
    {
        var counterId = IdConverterTo.ToString(segment.CounterId);

        var result = new DocumentNumberingSegmentDb
        {
            AsCounter = new DocumentCounterNumberingSegmentDb
            {
                CounterId = counterId
            },
            Data = data
        };

        return result;
    }

    internal static DocumentCounterNumberingSegment ToDomain(DocumentNumberingSegmentData data, DocumentCounterNumberingSegmentDb segment)
    {
        Id<Counter> counterId = IdConverterFrom<Counter>.FromString(segment.CounterId);

        var result = new DocumentCounterNumberingSegment(data, counterId);

        return result;
    }
}
