using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Attachments;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Booleans;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Dates;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Numbers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Tuples;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Types;

internal static class DocumentAttributeTypeInternalFromDomainConverter
{
    internal static DocumentAttributeTypeInternal FromDomain(DocumentAttributeType type)
    {
        DocumentAttributeTypeInternal result = type switch
        {
            DocumentAttachmentAttributeType => AttachmentDocumentAttributeTypeInternal.Instance,
            DocumentBooleanAttributeType => BooleanDocumentAttributeTypeInternal.Instance,
            DocumentDateAttributeType => DateDocumentAttributeTypeInternal.Instance,
            DocumentNumberAttributeType t => ToNumber(t),
            DocumentReferenceAttributeType t => ToReference(t),
            DocumentStringAttributeType => StringDocumentAttributeTypeInternal.Instance,
            DocumentTupleAttributeType => TupleDocumentAttributeTypeInternal.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static NumberDocumentAttributeTypeInternal ToNumber(DocumentNumberAttributeType type)
    {
        var result = new NumberDocumentAttributeTypeInternal(type.Precision);

        return result;
    }

    private static ReferenceDocumentAttributeTypeInternal ToReference(DocumentReferenceAttributeType type)
    {
        Metadata<ReferenceDocumentAttributeTypeInternal> referenceType =
            MetadataConverterFrom<ReferenceDocumentAttributeTypeInternal>.From(type.ReferenceType);

        var result = new ReferenceDocumentAttributeTypeInternal(referenceType);

        return result;
    }
}
