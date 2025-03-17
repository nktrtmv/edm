using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types.Inheritors.Dates;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types.Inheritors.References;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types.Inheritors.Strings;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Strings;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types;

internal static class DocumentRegistryRoleTypeExternalConverter
{
    internal static SearchDocumentRegistryRoleType ToDomain(DocumentRegistryRoleTypeExternal type)
    {
        SearchDocumentRegistryRoleType result = type switch
        {
            DocumentBooleanRegistryRoleTypeExternal => SearchDocumentBooleanRegistryRoleType.Instance,
            DocumentDateRegistryRoleTypeExternal => SearchDocumentDateRegistryRoleType.Instance,
            DocumentNumberRegistryRoleTypeExternal => SearchDocumentNumberRegistryRoleType.Instance,
            DocumentReferenceRegistryRoleTypeExternal t => new SearchDocumentReferenceRegistryRoleType(t.ReferenceType),
            DocumentStringRegistryRoleTypeExternal => SearchDocumentStringRegistryRoleType.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
