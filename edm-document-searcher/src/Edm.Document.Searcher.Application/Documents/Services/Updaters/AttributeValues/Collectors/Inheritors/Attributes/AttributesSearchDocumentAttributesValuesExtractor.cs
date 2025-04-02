using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.
    Attributes;

internal sealed class AttributesSearchDocumentAttributesValuesExtractor : ISearchDocumentAttributesValuesCollector
{
    Task ISearchDocumentAttributesValuesCollector.Collect(
        SearchDocumentUpdaterContext context,
        List<SearchDocumentAttributeValueInternal> attributesValues,
        CancellationToken _)
    {
        SearchDocumentAttributeValueInternal[] result = context.Document.AttributesValues
            .SelectMany(v => Collect(v, context))
            .ToArray();

        attributesValues.AddRange(result);

        return Task.CompletedTask;
    }

    private static SearchDocumentAttributeValueInternal[] Collect(DocumentAttributeValueExternal attributeValue, SearchDocumentUpdaterContext context)
    {
        int[] registryRolesIds = attributeValue.Attribute.Data.RegistryRolesIds;

        SearchDocumentRegistryRoleInternal[] registryRoles = registryRolesIds
            .Select(i => context.RegistryRolesById.GetValueOrDefault(i))
            .OfType<SearchDocumentRegistryRoleInternal>()
            .ToArray();

        SearchDocumentAttributeValueInternal[] result =
            registryRoles.Select(r => SearchDocumentAttributeValueInternalFromExternalConverter.FromExternal(r, attributeValue)).ToArray();

        return result;
    }
}
