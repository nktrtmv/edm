using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.References;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Roles.Types;

internal static class DocumentRegistryRoleTypeExternalFromDomainConverter
{
    internal static DocumentRegistryRoleTypeExternal FromDto(DocumentRegistryRoleTypeDto type)
    {
        DocumentRegistryRoleTypeExternal result = type.TypeCase switch
        {
            DocumentRegistryRoleTypeDto.TypeOneofCase.AsBoolean => new DocumentBooleanRegistryRoleTypeExternal(),
            DocumentRegistryRoleTypeDto.TypeOneofCase.AsDate => new DocumentDateRegistryRoleTypeExternal((int)type.AsDate.DisplayType),
            DocumentRegistryRoleTypeDto.TypeOneofCase.AsNumber => new DocumentNumberRegistryRoleTypeExternal(type.AsNumber.Precision),
            DocumentRegistryRoleTypeDto.TypeOneofCase.AsString => new DocumentStringRegistryRoleTypeExternal(),
            DocumentRegistryRoleTypeDto.TypeOneofCase.AsReference => new DocumentReferenceRegistryRoleTypeExternal(
                type.AsReference.ReferenceType,
                (int)type.AsReference.DisplayType,
                null),
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
