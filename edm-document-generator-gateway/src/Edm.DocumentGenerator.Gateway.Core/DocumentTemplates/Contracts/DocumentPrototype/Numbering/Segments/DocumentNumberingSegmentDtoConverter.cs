using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;

public static class DocumentNumberingSegmentDtoConverter
{
    public static DocumentNumberingSegmentDto ToDto(DocumentNumberingSegmentBff bff)
    {
        var result = bff switch
        {
            DocumentConstantNumberingSegmentBff constantBff => ToConstantDto(constantBff),
            DocumentCounterNumberingSegmentBff counterBff => ToCounterDto(counterBff),
            DocumentDateNumberingSegmentBff dateBff => ToDateDto(dateBff),
            _ => throw new ArgumentTypeOutOfRangeException(bff)
        };

        return result;
    }

    private static DocumentNumberingSegmentDto ToConstantDto(DocumentConstantNumberingSegmentBff constantBff)
    {
        var result = new DocumentNumberingSegmentDto
        {
            AsConstant = new DocumentConstantNumberingSegmentDto
            {
                Value = constantBff.Value
            },
            Data = ToDataDto(constantBff)
        };

        return result;
    }

    private static DocumentNumberingSegmentDto ToCounterDto(DocumentCounterNumberingSegmentBff counterBff)
    {
        var result = new DocumentNumberingSegmentDto
        {
            AsCounter = new DocumentCounterNumberingSegmentDto
            {
                CounterId = counterBff.CounterId
            },
            Data = ToDataDto(counterBff)
        };

        return result;
    }

    private static DocumentNumberingSegmentDto ToDateDto(DocumentDateNumberingSegmentBff dateBff)
    {
        var result = new DocumentNumberingSegmentDto
        {
            AsDate = new DocumentDateNumberingSegmentDto(),
            Data = ToDataDto(dateBff)
        };

        return result;
    }

    private static DocumentNumberingSegmentDataDto ToDataDto(DocumentNumberingSegmentBff dataBff)
    {
        var result = new DocumentNumberingSegmentDataDto
        {
            Format = dataBff.Format,
            Id = dataBff.Id
        };

        return result;
    }
}
