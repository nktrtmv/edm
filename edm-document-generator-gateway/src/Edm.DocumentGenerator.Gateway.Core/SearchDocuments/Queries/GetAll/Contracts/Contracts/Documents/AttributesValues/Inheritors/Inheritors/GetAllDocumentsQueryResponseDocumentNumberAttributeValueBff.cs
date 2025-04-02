namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

public sealed class GetAllDocumentsQueryResponseDocumentNumberAttributeValueBff : GetAllDocumentsQueryResponseDocumentAttributeValueBff
{
    public required long[] Values { get; init; }
}
