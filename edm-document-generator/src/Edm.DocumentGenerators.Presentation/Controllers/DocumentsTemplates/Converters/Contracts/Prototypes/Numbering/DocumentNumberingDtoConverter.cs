using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering.Segments;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering;

internal static class DocumentNumberingDtoConverter
{
    internal static DocumentNumberingDto FromInternal(DocumentNumberingInternal numbering)
    {
        DocumentNumberingSegmentDto[] segments = numbering.Segments
            .Select(DocumentNumberingSegmentDtoConverter.FromInternal)
            .ToArray();

        var result = new DocumentNumberingDto
        {
            Segments = { segments }
        };

        return result;
    }

    internal static DocumentNumberingInternal ToInternal(DocumentNumberingDto numbering)
    {
        DocumentNumberingSegmentInternal[] segments = numbering.Segments
            .Select(DocumentNumberingSegmentDtoConverter.ToInternal)
            .ToArray();

        var result = new DocumentNumberingInternal(segments);

        return result;
    }
}
