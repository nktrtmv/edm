using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors.JsonFields;

internal static class SearchDocumentJsonFieldAlias
{
    internal const string RegistryRoleId = nameof(SearchDocumentAttributeValueDb.RegistryRoleId);
    internal const string Values = nameof(SearchDocumentAttributeValueDbGeneric<SearchDocumentAttributeValueDb>.Values);
    internal const string AttributesValues = "d.attributes_values";
}
