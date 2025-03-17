using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

internal static class GetAllDocumentsQueryResponseDocumentBooleanAttributeValueBffConverter
{
    internal static GetAllDocumentsQueryResponseDocumentBooleanAttributeValueBff FromDto(
        string registryRoleId,
        GetDocumentsQueryResponseSearchDocumentBooleanAttributeValue attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var result = new GetAllDocumentsQueryResponseDocumentBooleanAttributeValueBff
        {
            RegistryRoleId = registryRoleId,
            Values = values
        };

        return result;
    }
}
