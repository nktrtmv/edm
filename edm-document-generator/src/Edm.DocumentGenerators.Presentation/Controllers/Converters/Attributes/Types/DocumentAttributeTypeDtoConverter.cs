using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.Types;

internal static class DocumentAttributeTypeDtoConverter
{
    internal static DocumentAttributeTypeDto FromInternal(DocumentAttributeTypeInternal type)
    {
        DocumentAttributeTypeDto result = type switch
        {
            AttachmentDocumentAttributeTypeInternal => new DocumentAttributeTypeDto { AsAttachment = ToAttachment() },
            BooleanDocumentAttributeTypeInternal => new DocumentAttributeTypeDto { AsBoolean = ToBoolean() },
            DateDocumentAttributeTypeInternal => new DocumentAttributeTypeDto { AsDate = ToDate() },
            NumberDocumentAttributeTypeInternal => new DocumentAttributeTypeDto { AsNumber = ToNumber() },
            ReferenceDocumentAttributeTypeInternal t => new DocumentAttributeTypeDto { AsReference = ToReference(t) },
            StringDocumentAttributeTypeInternal => new DocumentAttributeTypeDto { AsString = ToString() },
            TupleDocumentAttributeTypeInternal => new DocumentAttributeTypeDto { AsTuple = ToTuple() },
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static DocumentAttachmentAttributeTypeDto ToAttachment()
    {
        var result = new DocumentAttachmentAttributeTypeDto();

        return result;
    }

    private static DocumentBooleanAttributeTypeDto ToBoolean()
    {
        var result = new DocumentBooleanAttributeTypeDto();

        return result;
    }

    private static DocumentDateAttributeTypeDto ToDate()
    {
        var result = new DocumentDateAttributeTypeDto();

        return result;
    }

    private static DocumentNumberAttributeTypeDto ToNumber()
    {
        var result = new DocumentNumberAttributeTypeDto();

        return result;
    }

    private static DocumentReferenceAttributeTypeDto ToReference(ReferenceDocumentAttributeTypeInternal type)
    {
        var referenceType = MetadataConverterTo.ToString(type.ReferenceType);

        var result = new DocumentReferenceAttributeTypeDto
        {
            ReferenceType = referenceType
        };

        return result;
    }

    private new static DocumentStringAttributeTypeDto ToString()
    {
        var result = new DocumentStringAttributeTypeDto();

        return result;
    }

    private static DocumentTupleAttributeTypeDto ToTuple()
    {
        var result = new DocumentTupleAttributeTypeDto();

        return result;
    }
}
