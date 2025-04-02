using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Date;

public sealed record DocumentDateAttributeExternal(DocumentAttributeDataExternal Data) : DocumentAttributeExternal(Data);
