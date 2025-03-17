using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Documents.Notifiers.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values.SendNotification.Notifications.Parameters;

internal static class DocumentNotificationParameterDtoConverter
{
    internal static DocumentNotificationParameterDto FromDomain(SendNotificationDocumentNotifierRequestNotificationParameter parameter)
    {
        DocumentNotificationParameterDto result = parameter.Value switch
        {
            AttachmentDocumentAttributeValue v => new DocumentNotificationParameterDto { AsAttachment = ToAttachment(v) },
            BooleanDocumentAttributeValue v => new DocumentNotificationParameterDto { AsBool = ToBoolean(v) },
            DateDocumentAttributeValue v => new DocumentNotificationParameterDto { AsDate = ToDate(v) },
            NumberDocumentAttributeValue v => new DocumentNotificationParameterDto { AsNumber = ToNumber(v) },
            ReferenceDocumentAttributeValue v => new DocumentNotificationParameterDto { AsReference = ToReference(v) },
            StringDocumentAttributeValue v => new DocumentNotificationParameterDto { AsString = ToString(v) },
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        var templateParameterId = IdConverterTo.ToString(parameter.Id);

        result.TemplateParameterId = templateParameterId;

        return result;
    }

    private static DocumentAttachmentNotificationParameterDto ToAttachment(AttachmentDocumentAttributeValue attributeValue)
    {
        string[] value = attributeValue.Values.ToArray();

        var result = new DocumentAttachmentNotificationParameterDto
        {
            Value = { value }
        };

        return result;
    }

    private static DocumentBoolNotificationParameterDto ToBoolean(BooleanDocumentAttributeValue attributeValue)
    {
        bool[] value = attributeValue.Values.ToArray();

        var result = new DocumentBoolNotificationParameterDto
        {
            Value = { value }
        };

        return result;
    }

    private static DocumentDateNotificationParameterDto ToDate(DateDocumentAttributeValue attributeValue)
    {
        Timestamp[] value = attributeValue.Values.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new DocumentDateNotificationParameterDto
        {
            Value = { value }
        };

        return result;
    }

    private static DocumentNumberNotificationParameterDto ToNumber(NumberDocumentAttributeValue attributeValue)
    {
        long[] value = attributeValue.Values.Select(NumberConverterTo.ToLong).ToArray();

        var result = new DocumentNumberNotificationParameterDto
        {
            Value = { value }
        };

        return result;
    }

    private static DocumentReferenceNotificationParameterDto ToReference(ReferenceDocumentAttributeValue attributeValue)
    {
        if (attributeValue.Attribute is not DocumentReferenceAttribute referenceAttribute)
        {
            throw new UnsupportedTypeArgumentException<DocumentReferenceAttribute>(attributeValue.Attribute);
        }

        var referenceType = MetadataConverterTo.ToString(referenceAttribute.ReferenceType);

        string[] value = attributeValue.Values.ToArray();

        var result = new DocumentReferenceNotificationParameterDto
        {
            ReferenceType = referenceType,
            Value = { value }
        };

        return result;
    }

    private static DocumentStringNotificationParameterDto ToString(StringDocumentAttributeValue attributeValue)
    {
        string[] value = attributeValue.Values.ToArray();

        var result = new DocumentStringNotificationParameterDto
        {
            Value = { value }
        };

        return result;
    }
}
