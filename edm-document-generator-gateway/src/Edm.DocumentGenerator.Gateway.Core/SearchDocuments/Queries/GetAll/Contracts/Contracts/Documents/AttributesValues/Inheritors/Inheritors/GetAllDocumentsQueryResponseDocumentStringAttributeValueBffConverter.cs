using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

internal static class GetAllDocumentsQueryResponseDocumentStringAttributeValueBffConverter
{
    internal static GetAllDocumentsQueryResponseDocumentStringAttributeValueBff FromDto(
        string registryRoleId,
        GetDocumentsQueryResponseSearchDocumentStringAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new GetAllDocumentsQueryResponseDocumentStringAttributeValueBff
        {
            RegistryRoleId = registryRoleId,
            Values = values
        };

        return result;
    }
}
