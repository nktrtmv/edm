namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Tuple.InnerValue;

public sealed class DocumentTupleAttributeInnerValueExternal(DocumentAttributeValueExternal[] innerValues)
{
    public DocumentAttributeValueExternal[] InnerValues { get; init; } = innerValues;
}
