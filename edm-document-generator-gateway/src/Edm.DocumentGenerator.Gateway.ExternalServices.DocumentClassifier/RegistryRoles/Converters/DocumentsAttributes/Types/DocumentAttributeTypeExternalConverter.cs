using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.DocumentsAttributes.Types;

internal static class DocumentAttributeTypeExternalConverter
{
    internal static DocumentAttributeTypeExternal FromDto(DocumentAttributeTypeDto type)
    {
        DocumentAttributeTypeExternal result = type.TypeCase switch
        {
            DocumentAttributeTypeDto.TypeOneofCase.AsBoolean => DocumentBooleanAttributeTypeExternal.Instance,
            DocumentAttributeTypeDto.TypeOneofCase.AsAttachment => new DocumentAttachmentAttributeTypeExternal(),
            DocumentAttributeTypeDto.TypeOneofCase.AsDate => DocumentDateAttributeTypeExternal.Instance,
            DocumentAttributeTypeDto.TypeOneofCase.AsNumber => DocumentNumberAttributeTypeExternal.Instance,
            DocumentAttributeTypeDto.TypeOneofCase.AsReference => new DocumentReferenceAttributeTypeExternal(type.AsReference.ReferenceTypeId),
            DocumentAttributeTypeDto.TypeOneofCase.AsString => DocumentStringAttributeTypeExternal.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(type.TypeCase)
        };

        return result;
    }
}
