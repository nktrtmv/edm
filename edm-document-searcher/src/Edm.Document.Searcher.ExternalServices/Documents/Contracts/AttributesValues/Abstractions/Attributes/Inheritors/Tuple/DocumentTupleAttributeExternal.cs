using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Tuple;

public sealed record DocumentTupleAttributeExternal(DocumentAttributeDataExternal Data) : DocumentAttributeExternal(Data);
