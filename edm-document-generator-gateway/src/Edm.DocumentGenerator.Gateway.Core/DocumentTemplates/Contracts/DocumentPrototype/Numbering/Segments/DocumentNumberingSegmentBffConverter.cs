using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;

public static class DocumentNumberingSegmentBffConverter
{
    public static DocumentNumberingSegmentBff ToBff(DocumentNumberingSegmentDto dto)
    {
        DocumentNumberingSegmentBff result = dto.ValueCase switch
        {
            DocumentNumberingSegmentDto.ValueOneofCase.AsConstant => ToConstantBff(dto),
            DocumentNumberingSegmentDto.ValueOneofCase.AsCounter => ToCounterBff(dto),
            DocumentNumberingSegmentDto.ValueOneofCase.AsDate => ToDateBff(dto),
            _ => throw new ArgumentTypeOutOfRangeException(dto.ValueCase)
        };

        return result;
    }

    private static DocumentConstantNumberingSegmentBff ToConstantBff(DocumentNumberingSegmentDto dto)
    {
        var result = new DocumentConstantNumberingSegmentBff
        {
            Id = dto.Data.Id,
            Format = dto.Data.Format,
            Value = dto.AsConstant.Value
        };

        return result;
    }

    private static DocumentCounterNumberingSegmentBff ToCounterBff(DocumentNumberingSegmentDto dto)
    {
        var result = new DocumentCounterNumberingSegmentBff
        {
            Id = dto.Data.Id,
            Format = dto.Data.Format,
            CounterId = dto.AsCounter.CounterId
        };

        return result;
    }

    private static DocumentDateNumberingSegmentBff ToDateBff(DocumentNumberingSegmentDto dto)
    {
        var result = new DocumentDateNumberingSegmentBff
        {
            Id = dto.Data.Id,
            Format = dto.Data.Format
        };

        return result;
    }
}
