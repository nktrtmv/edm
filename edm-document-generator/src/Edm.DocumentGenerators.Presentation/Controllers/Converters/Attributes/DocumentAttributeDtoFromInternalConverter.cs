using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Attachments;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Booleans;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Dates;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Numbers;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Strings;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Tuples;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.Abstractions.Data;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes;

internal static class DocumentAttributeDtoFromInternalConverter
{
    internal static DocumentAttributeDto FromInternal(DocumentAttributeInternal attribute)
    {
        DocumentAttributeDto result = attribute switch
        {
            DocumentAttachmentAttributeInternal a => new DocumentAttributeDto { AsAttachment = ToAttachment(a) },
            DocumentBooleanAttributeInternal a => new DocumentAttributeDto { AsBoolean = ToBoolean(a) },
            DocumentDateAttributeInternal a => new DocumentAttributeDto { AsDate = ToDate(a) },
            DocumentNumberAttributeInternal a => new DocumentAttributeDto { AsNumber = ToNumber(a) },
            DocumentReferenceAttributeInternal a => new DocumentAttributeDto { AsReference = ToReference(a) },
            DocumentStringAttributeInternal a => new DocumentAttributeDto { AsString = ToString(a) },
            DocumentTupleAttributeInternal a => new DocumentAttributeDto { AsTuple = ToTuple(a) },
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        DocumentAttributeDataDto data = DocumentAttributeDataDtoConverter.FromInternal(attribute.Data);

        result.Data = data;

        return result;
    }

    private static DocumentStringAttributeDto ToString(DocumentStringAttributeInternal attribute)
    {
        var result = new DocumentStringAttributeDto
        {
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentAttachmentAttributeDto ToAttachment(DocumentAttachmentAttributeInternal attribute)
    {
        var result = new DocumentAttachmentAttributeDto
        {
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentBooleanAttributeDto ToBoolean(DocumentBooleanAttributeInternal attribute)
    {
        var result = new DocumentBooleanAttributeDto
        {
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentDateAttributeDto ToDate(DocumentDateAttributeInternal attribute)
    {
        Timestamp[] defaultValues = attribute.DefaultValues.Select(Timestamp.FromDateTime).ToArray();

        var result = new DocumentDateAttributeDto
        {
            DefaultValues = { defaultValues }
        };

        return result;
    }

    private static DocumentNumberAttributeDto ToNumber(DocumentNumberAttributeInternal attribute)
    {
        var result = new DocumentNumberAttributeDto
        {
            Precision = attribute.Precision,
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentReferenceAttributeDto ToReference(DocumentReferenceAttributeInternal attribute)
    {
        var referenceType = MetadataConverterTo.ToString(attribute.ReferenceType);

        var result = new DocumentReferenceAttributeDto
        {
            ReferenceType = referenceType,
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentTupleAttributeDto ToTuple(DocumentTupleAttributeInternal attribute)
    {
        DocumentAttributeDto[] innerAttributes = attribute.InnerAttributes.Select(FromInternal).ToArray();

        var result = new DocumentTupleAttributeDto
        {
            InnerAttributes = { innerAttributes }
        };

        return result;
    }
}
