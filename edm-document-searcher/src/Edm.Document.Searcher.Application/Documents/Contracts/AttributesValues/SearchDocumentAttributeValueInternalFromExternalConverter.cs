using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Number;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Boolean;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Date;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Number;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.String;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.GenericSubdomain.Extensions.Types;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;

internal static class SearchDocumentAttributeValueInternalFromExternalConverter
{
    internal static SearchDocumentAttributeValueInternal FromExternal(SearchDocumentRegistryRoleInternal registryRole, DocumentAttributeValueExternal value)
    {
        SearchDocumentAttributeValueInternal result = value switch
        {
            DocumentBooleanAttributeValueExternal v => ToBoolean(v, registryRole),
            DocumentDateAttributeValueExternal v => ToDate(v, registryRole),
            DocumentNumberAttributeValueExternal v => ToNumber(v, registryRole),
            DocumentReferenceAttributeValueExternal v => ToReference(v, registryRole),
            DocumentStringAttributeValueExternal v => ToString(v, registryRole),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }

    private static SearchDocumentBooleanAttributeValueInternal ToBoolean(
        DocumentBooleanAttributeValueExternal value,
        SearchDocumentRegistryRoleInternal registryRoleId)
    {
        var result = new SearchDocumentBooleanAttributeValueInternal(registryRoleId, value.Values);

        return result;
    }

    private static SearchDocumentDateAttributeValueInternal ToDate(
        DocumentDateAttributeValueExternal value,
        SearchDocumentRegistryRoleInternal registryRoleId)
    {
        UtcDateTime<SearchDocumentDateAttributeValueInternal>[] values =
            value.Values.Select(UtcDateTimeConverterFrom<SearchDocumentDateAttributeValueInternal>.From).ToArray();

        var result = new SearchDocumentDateAttributeValueInternal(registryRoleId, values);

        return result;
    }

    private static SearchDocumentNumberAttributeValueInternal ToNumber(
        DocumentNumberAttributeValueExternal value,
        SearchDocumentRegistryRoleInternal registryRoleId)
    {
        Number<SearchDocumentNumberAttributeValueInternal>[] values =
            value.Values.Select(NumberConverterFrom<SearchDocumentNumberAttributeValueInternal>.From).ToArray();

        DocumentNumberAttributeExternal attribute = TypeCasterTo<DocumentNumberAttributeExternal>.CastRequired(value.Attribute);

        var result = new SearchDocumentNumberAttributeValueInternal(registryRoleId, values, attribute.Precision);

        return result;
    }

    private static SearchDocumentReferenceAttributeValueInternal ToReference(
        DocumentReferenceAttributeValueExternal value,
        SearchDocumentRegistryRoleInternal registryRoleId)
    {
        DocumentReferenceAttributeExternal attribute = TypeCasterTo<DocumentReferenceAttributeExternal>.CastRequired(value.Attribute);

        var result = new SearchDocumentReferenceAttributeValueInternal(registryRoleId, value.Values, attribute.ReferenceType);

        return result;
    }

    private static SearchDocumentStringAttributeValueInternal ToString(
        DocumentStringAttributeValueExternal value,
        SearchDocumentRegistryRoleInternal registryRoleId)
    {
        var result = new SearchDocumentStringAttributeValueInternal(registryRoleId, value.Values);

        return result;
    }
}
