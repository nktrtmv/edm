namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

public sealed class GetAllDocumentsQueryResponseDocumentDateAttributeValueBff : GetAllDocumentsQueryResponseDocumentAttributeValueBff
{
    public required DateTime[] Values { get; init; }
}
