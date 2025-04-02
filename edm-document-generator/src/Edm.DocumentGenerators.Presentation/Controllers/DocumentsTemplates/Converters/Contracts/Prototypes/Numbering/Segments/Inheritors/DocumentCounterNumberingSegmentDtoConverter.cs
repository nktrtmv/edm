using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments.Inheritors;

public static class DocumentCounterNumberingSegmentDtoConverter
{
    internal static DocumentNumberingSegmentDto FromInternal(DocumentNumberingSegmentDataDto data, DocumentCounterNumberingSegmentInternal segment)
    {
        var counterUd = IdConverterTo.ToString(segment.CounterId);

        var result = new DocumentNumberingSegmentDto
        {
            AsCounter = new DocumentCounterNumberingSegmentDto
            {
                CounterId = counterUd
            },
            Data = data
        };

        return result;
    }

    internal static DocumentCounterNumberingSegmentInternal ToInternal(DocumentNumberingSegmentDataInternal data, DocumentCounterNumberingSegmentDto segment)
    {
        Id<CounterInternal> counterId = IdConverterFrom<CounterInternal>.FromString(segment.CounterId);

        var result = new DocumentCounterNumberingSegmentInternal(data, counterId);

        return result;
    }
}
