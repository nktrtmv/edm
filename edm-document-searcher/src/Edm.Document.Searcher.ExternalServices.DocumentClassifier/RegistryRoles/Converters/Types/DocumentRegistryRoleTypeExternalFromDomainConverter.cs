using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Strings;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Types;

internal static class DocumentRegistryRoleTypeExternalFromDomainConverter
{
    internal static DocumentRegistryRoleTypeExternal FromDto(DocumentRegistryRoleTypeDto type)
    {
        DocumentRegistryRoleTypeExternal result = type.TypeCase switch
        {
            DocumentRegistryRoleTypeDto.TypeOneofCase.AsBoolean => DocumentBooleanRegistryRoleTypeExternal.Instance,

            DocumentRegistryRoleTypeDto.TypeOneofCase.AsDate => DocumentDateRegistryRoleTypeExternal.Instance,

            DocumentRegistryRoleTypeDto.TypeOneofCase.AsNumber => ToNumber(type.AsNumber),

            DocumentRegistryRoleTypeDto.TypeOneofCase.AsReference => ToReference(type.AsReference),

            DocumentRegistryRoleTypeDto.TypeOneofCase.AsString => DocumentStringRegistryRoleTypeExternal.Instance,

            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static DocumentNumberRegistryRoleTypeExternal ToNumber(DocumentNumberRegistryRoleTypeDto type)
    {
        var result = new DocumentNumberRegistryRoleTypeExternal(type.Precision);

        return result;
    }

    private static DocumentReferenceRegistryRoleTypeExternal ToReference(DocumentReferenceRegistryRoleTypeDto type)
    {
        var result = new DocumentReferenceRegistryRoleTypeExternal(type.ReferenceType);

        return result;
    }
}
