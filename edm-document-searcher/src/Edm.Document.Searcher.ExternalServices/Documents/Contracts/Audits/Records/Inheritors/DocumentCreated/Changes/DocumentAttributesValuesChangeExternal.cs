using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated.Changes;

public sealed record DocumentAttributesValuesChangeExternal(DocumentAttributeValueExternal From, DocumentAttributeValueExternal To);
