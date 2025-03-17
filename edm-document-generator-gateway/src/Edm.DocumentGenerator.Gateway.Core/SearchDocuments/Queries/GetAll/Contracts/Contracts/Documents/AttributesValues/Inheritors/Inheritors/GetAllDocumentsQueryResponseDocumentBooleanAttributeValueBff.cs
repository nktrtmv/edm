namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

public sealed class GetAllDocumentsQueryResponseDocumentBooleanAttributeValueBff : GetAllDocumentsQueryResponseDocumentAttributeValueBff
{
    public required bool[] Values { get; init; }
}
