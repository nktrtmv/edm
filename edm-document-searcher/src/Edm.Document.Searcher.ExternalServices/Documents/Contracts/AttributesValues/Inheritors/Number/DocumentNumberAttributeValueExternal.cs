using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Number;

public sealed class DocumentNumberAttributeValueExternal(DocumentAttributeExternal attribute, Number<DocumentNumberAttributeValueExternal>[] values)
    : DocumentAttributeValueExternalGeneric<Number<DocumentNumberAttributeValueExternal>>(attribute, values);
