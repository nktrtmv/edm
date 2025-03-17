using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single.
    Synchronous;

internal abstract class SynchronousSingleAttributesValuesCollector : SingleAttributesValuesCollector
{
    protected SynchronousSingleAttributesValuesCollector(int registryRoleId)
        : base(registryRoleId)
    {
    }

    protected override Task<SearchDocumentAttributeValueInternal?> Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole,
        CancellationToken cancellationToken)
    {
        SearchDocumentAttributeValueInternal? result = Collect(context, registryRole);

        return Task.FromResult(result);
    }

    protected abstract SearchDocumentAttributeValueInternal? Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole);
}
