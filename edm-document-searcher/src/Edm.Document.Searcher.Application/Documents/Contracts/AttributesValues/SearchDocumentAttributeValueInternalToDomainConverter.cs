using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;

internal static class SearchDocumentAttributeValueInternalToDomainConverter
{
    internal static SearchDocumentAttributeValue ToDomain(SearchDocumentAttributeValueInternal value)
    {
        int registryRoleId = value.RegistryRole.Id;

        SearchDocumentAttributeValue result = value switch
        {
            SearchDocumentBooleanAttributeValueInternal v => ToBoolean(v, registryRoleId),
            SearchDocumentDateAttributeValueInternal v => ToDate(v, registryRoleId),
            SearchDocumentNumberAttributeValueInternal v => ToNumber(v, registryRoleId),
            SearchDocumentReferenceAttributeValueInternal v => ToReference(v, registryRoleId),
            SearchDocumentStringAttributeValueInternal v => ToString(v, registryRoleId),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }

    private static SearchDocumentBooleanAttributeValue ToBoolean(
        SearchDocumentBooleanAttributeValueInternal value,
        int registryRoleId)
    {
        var result = new SearchDocumentBooleanAttributeValue(registryRoleId, value.Values);

        return result;
    }

    private static SearchDocumentDateAttributeValue ToDate(
        SearchDocumentDateAttributeValueInternal value,
        int registryRoleId)
    {
        UtcDateTime<SearchDocumentDateAttributeValue>[] values =
            value.Values.Select(UtcDateTimeConverterFrom<SearchDocumentDateAttributeValue>.From).ToArray();

        var result = new SearchDocumentDateAttributeValue(registryRoleId, values);

        return result;
    }

    private static SearchDocumentNumberAttributeValue ToNumber(
        SearchDocumentNumberAttributeValueInternal value,
        int registryRoleId)
    {
        Number<SearchDocumentNumberAttributeValue>[] values =
            value.Values.Select(NumberConverterFrom<SearchDocumentNumberAttributeValue>.From).ToArray();

        var result = new SearchDocumentNumberAttributeValue(registryRoleId, values);

        return result;
    }

    private static SearchDocumentReferenceAttributeValue ToReference(
        SearchDocumentReferenceAttributeValueInternal value,
        int registryRoleId)
    {
        List<ParentReferenceTypeAttributeValue>? parents = value.ParentReference?.Select(ToReference).ToList();
        var result = new SearchDocumentReferenceAttributeValue(
            registryRoleId,
            value.Values,
            value.ReferenceType,
            parents);

        return result;
    }

    private static ParentReferenceTypeAttributeValue ToReference(ParentReferenceTypeAttributeValueInternal model)
    {
        var result = new ParentReferenceTypeAttributeValue(model.ReferenceType, model.Values);

        return result;
    }

    private static SearchDocumentStringAttributeValue ToString(
        SearchDocumentStringAttributeValueInternal value,
        int registryRoleId)
    {
        var result = new SearchDocumentStringAttributeValue(registryRoleId, value.Values);

        return result;
    }
}
