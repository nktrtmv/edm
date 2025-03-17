using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types.Inheritors;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types;

internal static class DocumentAttributeTypeBffConverter
{
    internal static DocumentAttributeTypeBff FromDto(DocumentAttributeTypeExternal type)
    {
        DocumentAttributeTypeBff result = type switch
        {
            DocumentAttachmentAttributeTypeExternal => new DocumentAttachmentAttributeTypeBff(),
            DocumentBooleanAttributeTypeExternal => new DocumentBooleanAttributeTypeBff(),
            DocumentDateAttributeTypeExternal => new DocumentDateAttributeTypeBff(),
            DocumentNumberAttributeTypeExternal => new DocumentNumberAttributeTypeBff(),
            DocumentReferenceAttributeTypeExternal r => new DocumentReferenceAttributeTypeBff { ReferenceType = r.ReferenceType },
            DocumentStringAttributeTypeExternal => new DocumentStringAttributeTypeBff(),
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentAttributeTypeBff FromExternal(DocumentAttributeTypeExternal type)
    {
        DocumentAttributeTypeBff result = type switch
        {
            DocumentBooleanAttributeTypeExternal => new DocumentBooleanAttributeTypeBff(),
            DocumentDateAttributeTypeExternal => new DocumentDateAttributeTypeBff(),
            DocumentNumberAttributeTypeExternal => new DocumentNumberAttributeTypeBff(),
            DocumentReferenceAttributeTypeExternal t => new DocumentReferenceAttributeTypeBff { ReferenceType = t.ReferenceType },
            DocumentStringAttributeTypeExternal => new DocumentStringAttributeTypeBff(),
            DocumentAttachmentAttributeTypeExternal => new DocumentAttachmentAttributeTypeBff(),
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
