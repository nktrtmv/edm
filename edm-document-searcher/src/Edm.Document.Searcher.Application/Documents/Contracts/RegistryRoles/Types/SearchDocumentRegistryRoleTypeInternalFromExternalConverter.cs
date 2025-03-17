using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Dates;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Strings;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Strings;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types;

internal static class SearchDocumentRegistryRoleTypeInternalFromExternalConverter
{
    internal static SearchDocumentRegistryRoleTypeInternal FromExternal(DocumentRegistryRoleTypeExternal type)
    {
        SearchDocumentRegistryRoleTypeInternal result = type switch
        {
            DocumentBooleanRegistryRoleTypeExternal => SearchDocumentBooleanRegistryRoleTypeInternal.Instance,
            DocumentDateRegistryRoleTypeExternal => SearchDocumentDateRegistryRoleTypeInternal.Instance,
            DocumentNumberRegistryRoleTypeExternal t => ToNumber(t),
            DocumentReferenceRegistryRoleTypeExternal t => ToReference(t),
            DocumentStringRegistryRoleTypeExternal => SearchDocumentStringRegistryRoleTypeInternal.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static SearchDocumentNumberRegistryRoleTypeInternal ToNumber(DocumentNumberRegistryRoleTypeExternal type)
    {
        var result = new SearchDocumentNumberRegistryRoleTypeInternal(type.Precision);

        return result;
    }

    private static SearchDocumentReferenceRegistryRoleTypeInternal ToReference(DocumentReferenceRegistryRoleTypeExternal type)
    {
        var result = new SearchDocumentReferenceRegistryRoleTypeInternal(type.ReferenceType);

        return result;
    }
}
