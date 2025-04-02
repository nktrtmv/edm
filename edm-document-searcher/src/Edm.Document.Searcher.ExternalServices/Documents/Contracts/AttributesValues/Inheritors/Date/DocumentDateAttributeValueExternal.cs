using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Date;

public sealed class DocumentDateAttributeValueExternal(DocumentAttributeExternal attribute, UtcDateTime<DocumentDateAttributeValueExternal>[] values)
    : DocumentAttributeValueExternalGeneric<UtcDateTime<DocumentDateAttributeValueExternal>>(attribute, values);
