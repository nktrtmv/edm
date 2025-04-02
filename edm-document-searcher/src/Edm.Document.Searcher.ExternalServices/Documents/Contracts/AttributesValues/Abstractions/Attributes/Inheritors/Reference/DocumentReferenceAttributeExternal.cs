using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Reference;

public sealed record DocumentReferenceAttributeExternal(DocumentAttributeDataExternal Data, string ReferenceType)
    : DocumentAttributeExternal(Data);
