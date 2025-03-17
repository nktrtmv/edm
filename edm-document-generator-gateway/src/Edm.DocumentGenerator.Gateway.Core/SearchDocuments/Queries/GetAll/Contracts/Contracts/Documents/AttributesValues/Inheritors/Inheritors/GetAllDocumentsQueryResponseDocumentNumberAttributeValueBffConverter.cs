using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

internal static class GetAllDocumentsQueryResponseDocumentNumberAttributeValueBffConverter
{
    internal static GetAllDocumentsQueryResponseDocumentNumberAttributeValueBff FromDto(
        string registryRoleId,
        GetDocumentsQueryResponseSearchDocumentNumberAttributeValue attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var result = new GetAllDocumentsQueryResponseDocumentNumberAttributeValueBff
        {
            RegistryRoleId = registryRoleId,
            Values = values
        };

        return result;
    }
}
