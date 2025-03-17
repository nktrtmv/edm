using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single.Synchronous;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.
    TemplateIds;

internal sealed class TemplateIdSearchDocumentAttributesValuesExtractor() : SynchronousSingleAttributesValuesCollector(SearchDocumentRegistryRoleId.TemplateId)
{
    protected override SearchDocumentAttributeValueInternal Collect(SearchDocumentUpdaterContext context, SearchDocumentRegistryRoleInternal registryRole)
    {
        string[] values = [context.Document.TemplateId.Value];

        var result = new SearchDocumentStringAttributeValueInternal(registryRole, values);

        return result;
    }
}
