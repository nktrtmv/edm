using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors.Converters;

public static class DocumentCounterNumberingSegmentInternalConverter
{
    internal static DocumentCounterNumberingSegmentInternal FromDomain(DocumentNumberingSegmentDataInternal data, DocumentCounterNumberingSegment segment)
    {
        Id<CounterInternal> counterId = IdConverterFrom<CounterInternal>.From(segment.CounterId);

        var result = new DocumentCounterNumberingSegmentInternal(data, counterId);

        return result;
    }

    internal static DocumentCounterNumberingSegment ToDomain(DocumentNumberingSegmentData data, DocumentCounterNumberingSegmentInternal segment)
    {
        Id<Counter> counterId = IdConverterFrom<Counter>.From(segment.CounterId);

        var result = new DocumentCounterNumberingSegment(data, counterId);

        return result;
    }
}
