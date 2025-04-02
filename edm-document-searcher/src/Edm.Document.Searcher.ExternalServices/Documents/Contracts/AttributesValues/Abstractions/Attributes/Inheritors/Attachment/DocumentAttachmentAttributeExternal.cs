using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Attachment;

public sealed record DocumentAttachmentAttributeExternal(DocumentAttributeDataExternal Data) : DocumentAttributeExternal(Data);
