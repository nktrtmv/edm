using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Boolean;

public sealed record DocumentBooleanAttributeExternal(DocumentAttributeDataExternal Data) : DocumentAttributeExternal(Data);
