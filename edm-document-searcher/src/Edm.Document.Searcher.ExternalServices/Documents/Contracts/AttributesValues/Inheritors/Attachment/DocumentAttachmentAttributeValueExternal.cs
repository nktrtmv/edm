using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Attachment;

public sealed class DocumentAttachmentAttributeValueExternal(DocumentAttributeExternal attribute, string[] values)
    : DocumentAttributeValueExternalGeneric<string>(attribute, values);
