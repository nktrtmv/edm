using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments.Abstractions.Data;

internal static class DocumentNumberingSegmentDataDtoConverter
{
    internal static DocumentNumberingSegmentDataDto FromInternal(DocumentNumberingSegmentDataInternal data)
    {
        return new DocumentNumberingSegmentDataDto
        {
            Id = data.Id,
            Format = data.Format
        };
    }

    internal static DocumentNumberingSegmentDataInternal ToInternal(DocumentNumberingSegmentDataDto data)
    {
        return new DocumentNumberingSegmentDataInternal(data.Id, data.Format);
    }
}
