using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

// ReSharper disable ArrangeMethodOrOperatorBody

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.AttributesValues;

public static class DocumentAttributeValueDtoConverter
{
    public static DocumentAttributeValueInternal ToInternal(DocumentAttributeValueDto model)
    {
        string attributeId = model.AttributeId;

        DocumentAttributeValueInternal result = model.ValueCase switch
        {
            DocumentAttributeValueDto.ValueOneofCase.AsAttachment => ToAttachment(attributeId, model.AsAttachment),
            DocumentAttributeValueDto.ValueOneofCase.AsBoolean => ToBoolean(attributeId, model.AsBoolean),
            DocumentAttributeValueDto.ValueOneofCase.AsDate => ToDate(attributeId, model.AsDate),
            DocumentAttributeValueDto.ValueOneofCase.AsNumber => ToNumber(attributeId, model.AsNumber),
            DocumentAttributeValueDto.ValueOneofCase.AsReference => ToReference(attributeId, model.AsReference),
            DocumentAttributeValueDto.ValueOneofCase.AsString => ToString(attributeId, model.AsString),
            DocumentAttributeValueDto.ValueOneofCase.AsTuple => ToTuple(attributeId, model.AsTuple),
            _ => throw new ArgumentTypeOutOfRangeException(model.ValueCase)
        };

        return result;
    }

    public static DocumentAttributeValueDto ToDto(DocumentAttributeValueInternal model)
    {
        DocumentAttributeValueDto result = model switch
        {
            ReferenceDocumentAttributeValueInternal a => new DocumentAttributeValueDto
            {
                AsReference = new ReferenceDocumentAttributeValueDto { Values = { a.Values } }
            },
            AttachmentDocumentAttributeValueInternal a => new DocumentAttributeValueDto
            {
                AsAttachment = new AttachmentDocumentAttributeValueDto { Values = { a.Values } }
            },
            BooleanDocumentAttributeValueInternal a => new DocumentAttributeValueDto
            {
                AsBoolean = new BooleanDocumentAttributeValueDto { Values = { a.Values } }
            },
            DateDocumentAttributeValueInternal a => new DocumentAttributeValueDto
            {
                AsDate = new DateDocumentAttributeValueDto { Values = { a.Values.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray() } }
            },
            StringDocumentAttributeValueInternal a => new DocumentAttributeValueDto
            {
                AsString = new StringDocumentAttributeValueDto { Values = { a.Values } }
            },
            NumberDocumentAttributeValueInternal a => new DocumentAttributeValueDto
            {
                AsNumber = new NumberDocumentAttributeValueDto
                {
                    Values = { a.Values.Select(x => x.Value) }
                }
            },
            TupleDocumentAttributeValueInternal a => new DocumentAttributeValueDto
            {
                AsTuple = new TupleDocumentAttributeValueDto { Values = { a.Values.Select(ToTupleValue) } }
            },
            _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
        };

        result.AttributeId = model.AttributeId;

        return result;
    }

    private static DocumentAttributeValueInternal ToAttachment(string attributeId, AttachmentDocumentAttributeValueDto attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new AttachmentDocumentAttributeValueInternal(attributeId, values);

        return result;
    }

    private static DocumentAttributeValueInternal ToBoolean(string attributeId, BooleanDocumentAttributeValueDto attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new BooleanDocumentAttributeValueInternal(attributeId, values);

        return result;
    }

    private static DocumentAttributeValueInternal ToDate(string attributeId, DateDocumentAttributeValueDto attributeValue)
    {
        UtcDateTime<DateDocumentAttributeValueInternal>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<DateDocumentAttributeValueInternal>.FromTimestamp).ToArray();

        var result = new DateDocumentAttributeValueInternal(attributeId, values);

        return result;
    }

    private static DocumentAttributeValueInternal ToNumber(string attributeId, NumberDocumentAttributeValueDto attributeValue)
    {
        Number<NumberDocumentAttributeValueInternal>[] values =
            attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAttributeValueInternal>.FromLong).ToArray();

        var result = new NumberDocumentAttributeValueInternal(attributeId, values);

        return result;
    }

    private static DocumentAttributeValueInternal ToReference(string attributeId, ReferenceDocumentAttributeValueDto attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new ReferenceDocumentAttributeValueInternal(attributeId, values);

        return result;
    }

    private static DocumentAttributeValueInternal ToString(string attributeId, StringDocumentAttributeValueDto attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new StringDocumentAttributeValueInternal(attributeId, values);

        return result;
    }

    private static DocumentAttributeValueInternal ToTuple(string attributeId, TupleDocumentAttributeValueDto attributeValue)
    {
        TupleInnerValueDocumentAttributeValueInternal[] values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new TupleDocumentAttributeValueInternal(attributeId, values);

        return result;
    }

    private static TupleInnerValueDocumentAttributeValueInternal ToTupleValue(TupleInnerValueDocumentAttributeValueDto value)
    {
        DocumentAttributeValueInternal[] innerValues = value.InnerValues.Select(ToInternal).ToArray();

        var result = new TupleInnerValueDocumentAttributeValueInternal(innerValues);

        return result;
    }

    private static TupleInnerValueDocumentAttributeValueDto ToTupleValue(TupleInnerValueDocumentAttributeValueInternal value) =>
        new TupleInnerValueDocumentAttributeValueDto { InnerValues = { value.InnerValues.Select(ToDto).ToArray() } };
}
