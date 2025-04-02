using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Boolean;

public sealed class DocumentBooleanAttributeValueExternal(DocumentAttributeExternal attribute, bool[] values)
    : DocumentAttributeValueExternalGeneric<bool>(attribute, values);
