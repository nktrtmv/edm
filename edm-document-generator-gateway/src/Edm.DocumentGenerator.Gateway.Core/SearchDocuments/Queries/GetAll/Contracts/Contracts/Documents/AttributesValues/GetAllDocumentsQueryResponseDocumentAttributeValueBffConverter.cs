using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment.Context;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues;

internal static class GetAllDocumentsQueryResponseDocumentAttributeValueBffConverter
{
    internal static GetAllDocumentsQueryResponseDocumentAttributeValueBff FromDto(
        GetDocumentsQueryResponseSearchDocumentAttributeValue attributeValue,
        GetAllDocumentsQueryResponseDocumentBffContext conversionContext,
        DomainRoles domainRoles)
    {
        var registryRoleId = domainRoles.GetRegistryRoleNameById(attributeValue.RegistryRoleId);

        GetAllDocumentsQueryResponseDocumentAttributeValueBff result = attributeValue.ValueCase switch
        {
            GetDocumentsQueryResponseSearchDocumentAttributeValue.ValueOneofCase.AsBoolean =>
                GetAllDocumentsQueryResponseDocumentBooleanAttributeValueBffConverter.FromDto(registryRoleId, attributeValue.AsBoolean),

            GetDocumentsQueryResponseSearchDocumentAttributeValue.ValueOneofCase.AsDate =>
                GetAllDocumentsQueryResponseDocumentDateAttributeValueBffConverter.FromDto(registryRoleId, attributeValue.AsDate),

            GetDocumentsQueryResponseSearchDocumentAttributeValue.ValueOneofCase.AsNumber =>
                GetAllDocumentsQueryResponseDocumentNumberAttributeValueBffConverter.FromDto(registryRoleId, attributeValue.AsNumber),

            GetDocumentsQueryResponseSearchDocumentAttributeValue.ValueOneofCase.AsReference =>
                GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBffConverter.FromDto(registryRoleId, attributeValue.AsReference, conversionContext),

            GetDocumentsQueryResponseSearchDocumentAttributeValue.ValueOneofCase.AsString =>
                GetAllDocumentsQueryResponseDocumentStringAttributeValueBffConverter.FromDto(registryRoleId, attributeValue.AsString),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }
}
