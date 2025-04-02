using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering;

internal static class DocumentNumberingBffConverter
{
    public static DocumentNumberingBff ToBff(DocumentNumberingDto? dto)
    {
        if (dto == null)
        {
            return new DocumentNumberingBff
            {
                Segments = Array.Empty<DocumentNumberingSegmentBff>()
            };
        }

        DocumentNumberingSegmentBff[] segments = dto.Segments
            .Select(DocumentNumberingSegmentBffConverter.ToBff)
            .ToArray();

        var result = new DocumentNumberingBff
        {
            Segments = segments
        };

        return result;
    }

    public static DocumentNumberingDto ToDto(DocumentNumberingBff? source)
    {
        if (source == null)
        {
            return new DocumentNumberingDto();
        }

        DocumentNumberingSegmentDto[] segments = source.Segments
            .Select(DocumentNumberingSegmentDtoConverter.ToDto)
            .ToArray();

        var result = new DocumentNumberingDto
        {
            Segments = { segments }
        };

        return result;
    }
}
