using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.String;

public sealed class DocumentStringAttributeValueExternal(DocumentAttributeExternal attribute, string[] values)
    : DocumentAttributeValueExternalGeneric<string>(attribute, values);
