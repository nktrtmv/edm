namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

public sealed class GetAllDocumentsQueryResponseDocumentStringAttributeValueBff : GetAllDocumentsQueryResponseDocumentAttributeValueBff
{
    public required string[] Values { get; init; }
}
