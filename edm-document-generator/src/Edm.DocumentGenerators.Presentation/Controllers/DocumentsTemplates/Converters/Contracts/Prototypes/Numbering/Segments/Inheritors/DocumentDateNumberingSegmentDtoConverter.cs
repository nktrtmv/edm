using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments.Inheritors;

public static class DocumentDateNumberingSegmentDtoConverter
{
    internal static DocumentNumberingSegmentDto FromInternal(DocumentNumberingSegmentDataDto data)
    {
        var result = new DocumentNumberingSegmentDto
        {
            AsDate = new DocumentDateNumberingSegmentDto(),
            Data = data
        };

        return result;
    }

    internal static DocumentDateNumberingSegmentInternal ToInternal(DocumentNumberingSegmentDataInternal data)
    {
        var result = new DocumentDateNumberingSegmentInternal(data);

        return result;
    }
}
