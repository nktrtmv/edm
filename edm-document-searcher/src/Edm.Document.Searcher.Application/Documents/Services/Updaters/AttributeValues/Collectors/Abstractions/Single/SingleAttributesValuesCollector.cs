using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single;

internal abstract class SingleAttributesValuesCollector : ISearchDocumentAttributesValuesCollector
{
    protected SingleAttributesValuesCollector(int registryRoleId)
    {
        RegistryRoleId = registryRoleId;
    }

    private int RegistryRoleId { get; }

    async Task ISearchDocumentAttributesValuesCollector.Collect(
        SearchDocumentUpdaterContext context,
        List<SearchDocumentAttributeValueInternal> attributesValues,
        CancellationToken cancellationToken)
    {
        SearchDocumentRegistryRoleInternal? registryRole =
            context.RegistryRolesById.GetValueOrDefault(RegistryRoleId);

        if (registryRole is null)
        {
            return;
        }

        SearchDocumentAttributeValueInternal? attributeValue = await Collect(context, registryRole, cancellationToken);

        if (attributeValue is null)
        {
            return;
        }

        attributesValues.Add(attributeValue);
    }

    protected abstract Task<SearchDocumentAttributeValueInternal?> Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole,
        CancellationToken cancellationToken);
}
