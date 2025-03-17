using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Number;

public sealed record DocumentNumberAttributeExternal(DocumentAttributeDataExternal Data, int Precision) : DocumentAttributeExternal(Data);
