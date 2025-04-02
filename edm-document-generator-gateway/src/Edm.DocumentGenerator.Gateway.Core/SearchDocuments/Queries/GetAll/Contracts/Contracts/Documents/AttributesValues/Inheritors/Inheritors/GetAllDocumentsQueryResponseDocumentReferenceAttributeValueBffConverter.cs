using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment.Context;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;

internal static class GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBffConverter
{
    internal static GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff FromDto(
        string registryRoleId,
        GetDocumentsQueryResponseSearchDocumentReferenceAttributeValue attributeValue,
        GetAllDocumentsQueryResponseDocumentBffContext conversionContext)
    {
        ReferenceTypeValueBff[] values = attributeValue.Values.Select(ReferenceTypeValueBff.CreateNotEnriched).ToArray();

        var result = new GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff
        {
            RegistryRoleId = registryRoleId,
            Values = values,
            ReferenceType = attributeValue.ReferenceType,
            Parents = attributeValue.ParentValues
                .Select(x => new GetAllDocumentsQueryResponseDocumentParentReferenceAttributeValueBff(x.ReferenceType, x.Values.ToList()))
                .ToList()
        };

        conversionContext.Enricher.Add(result);

        return result;
    }
}
