using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments.Inheritors;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments;

public static class DocumentNumberingSegmentDtoConverter
{
    internal static DocumentNumberingSegmentDto FromInternal(DocumentNumberingSegmentInternal segment)
    {
        DocumentNumberingSegmentDataDto data = DocumentNumberingSegmentDataDtoConverter.FromInternal(segment.Data);

        DocumentNumberingSegmentDto result = segment switch
        {
            DocumentConstantNumberingSegmentInternal constant => DocumentConstantNumberingSegmentDtoConverter.FromInternal(data, constant),
            DocumentCounterNumberingSegmentInternal counter => DocumentCounterNumberingSegmentDtoConverter.FromInternal(data, counter),
            DocumentDateNumberingSegmentInternal => DocumentDateNumberingSegmentDtoConverter.FromInternal(data),
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };

        return result;
    }

    internal static DocumentNumberingSegmentInternal ToInternal(DocumentNumberingSegmentDto segment)
    {
        DocumentNumberingSegmentDataInternal data = DocumentNumberingSegmentDataDtoConverter.ToInternal(segment.Data);

        DocumentNumberingSegmentInternal result = segment.ValueCase switch
        {
            DocumentNumberingSegmentDto.ValueOneofCase.AsConstant => DocumentConstantNumberingSegmentDtoConverter.ToInternal(data, segment.AsConstant),
            DocumentNumberingSegmentDto.ValueOneofCase.AsCounter => DocumentCounterNumberingSegmentDtoConverter.ToInternal(data, segment.AsCounter),
            DocumentNumberingSegmentDto.ValueOneofCase.AsDate => DocumentDateNumberingSegmentDtoConverter.ToInternal(data),
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };

        return result;
    }
}
