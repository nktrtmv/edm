using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Tuple.InnerValue;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Tuple;

public sealed class DocumentTupleAttributeValueExternal(DocumentAttributeExternal attribute, DocumentTupleAttributeInnerValueExternal[] values)
    : DocumentAttributeValueExternalGeneric<DocumentTupleAttributeInnerValueExternal>(attribute, values);
