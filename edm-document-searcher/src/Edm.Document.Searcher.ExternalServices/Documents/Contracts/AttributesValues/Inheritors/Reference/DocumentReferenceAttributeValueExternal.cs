using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;

public sealed class DocumentReferenceAttributeValueExternal(DocumentAttributeExternal attribute, string[] values)
    : DocumentAttributeValueExternalGeneric<string>(attribute, values);
