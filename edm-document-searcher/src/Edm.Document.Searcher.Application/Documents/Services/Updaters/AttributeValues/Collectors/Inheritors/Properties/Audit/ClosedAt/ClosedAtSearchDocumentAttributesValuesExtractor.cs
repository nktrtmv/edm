using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single.Synchronous;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.StagesTypes;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Audit.
    ClosedAt;

internal sealed class ClosedAtSearchDocumentAttributesValuesExtractor() : SynchronousSingleAttributesValuesCollector(SearchDocumentRegistryRoleId.ClosedAt)
{
    protected override SearchDocumentAttributeValueInternal? Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole)
    {
        if (context.Document.StageType != DocumentStageTypeExternal.InEffect)
        {
            return null;
        }

        UtcDateTime<SearchDocumentDateAttributeValueInternal> value =
            UtcDateTimeConverterFrom<SearchDocumentDateAttributeValueInternal>.From(context.Document.Audit.UpdatedDate);

        UtcDateTime<SearchDocumentDateAttributeValueInternal>[] values = [value];

        var result = new SearchDocumentDateAttributeValueInternal(registryRole, values);

        return result;
    }
}
