using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.String;

public sealed record DocumentStringAttributeExternal(DocumentAttributeDataExternal Data)
    : DocumentAttributeExternal(Data);
