using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single.Synchronous;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.
    Statuses;

internal sealed class StatusSearchDocumentAttributesValuesExtractor : SynchronousSingleAttributesValuesCollector
{
    public StatusSearchDocumentAttributesValuesExtractor()
        : base(SearchDocumentRegistryRoleId.Status)
    {
    }

    protected override SearchDocumentAttributeValueInternal Collect(SearchDocumentUpdaterContext context, SearchDocumentRegistryRoleInternal registryRole)
    {
        string[] values = { context.Document.Status.DisplayName };

        var result = new SearchDocumentStringAttributeValueInternal(registryRole, values);

        return result;
    }
}
