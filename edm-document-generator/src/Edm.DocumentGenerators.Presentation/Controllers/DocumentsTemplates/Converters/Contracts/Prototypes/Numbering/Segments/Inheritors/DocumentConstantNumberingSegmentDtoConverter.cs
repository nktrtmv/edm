using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments.Inheritors;

public static class DocumentConstantNumberingSegmentDtoConverter
{
    internal static DocumentNumberingSegmentDto FromInternal(DocumentNumberingSegmentDataDto data, DocumentConstantNumberingSegmentInternal segment)
    {
        var result = new DocumentNumberingSegmentDto
        {
            AsConstant = new DocumentConstantNumberingSegmentDto
            {
                Value = segment.Value
            },
            Data = data
        };

        return result;
    }

    internal static DocumentConstantNumberingSegmentInternal ToInternal(DocumentNumberingSegmentDataInternal data, DocumentConstantNumberingSegmentDto segment)
    {
        var result = new DocumentConstantNumberingSegmentInternal(data, segment.Value);

        return result;
    }
}
