using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;

namespace Edm.Document.Searcher.Domain.Documents.Services.Updaters.AttributesValues.Watchers;

internal static class SearchDocumentWatcherAttributeValueUpdater
{
    internal static void Update(SearchDocument document, int registryRoleId, string[] values)
    {
        SearchDocumentAttributeValue approvers = new SearchDocumentReferenceAttributeValue(registryRoleId, values, null);

        SearchDocumentAttributeValue[] attributesValues = document.AttributesValues
            .Where(v => v.RegistryRoleId != approvers.RegistryRoleId)
            .Append(approvers)
            .ToArray();

        document.SetAttributesValues(attributesValues);
    }
}
