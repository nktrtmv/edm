using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

internal static class GetAllDocumentsQueryResponseDocumentDateAttributeValueBffConverter
{
    internal static GetAllDocumentsQueryResponseDocumentDateAttributeValueBff FromDto(
        string registryRoleId,
        GetDocumentsQueryResponseSearchDocumentDateAttributeValue attributeValue)
    {
        var values = attributeValue.Values.Select(v => v.ToDateTime()).ToArray();

        var result = new GetAllDocumentsQueryResponseDocumentDateAttributeValueBff
        {
            RegistryRoleId = registryRoleId,
            Values = values
        };

        return result;
    }
}
