using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAllDocumentsStatuses.Converters;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAllDocumentsStatuses;

public sealed class GetAllDocumentsStatusesDocumentTemplatesService(DocumentTemplateService.DocumentTemplateServiceClient serviceClient)
    : DocumentTemplateServiceClientBase(serviceClient)
{
    public async Task<ReferenceTypeValueBff[]> Get(GetRegistryRolesStatusesSuggestionsQueryBff queryBff, CancellationToken cancellationToken)
    {
        var query = new GetAllDocumentsStatusesDocumentTemplatesQuery { DomainId = queryBff.DomainId };

        var response =
            await DocumentTemplateServiceClient.GetAllDocumentsStatusesAsync(query, cancellationToken: cancellationToken);

        ReferenceTypeValueBff[] statuses = response.Statuses.Select(GetAllDocumentsStatusesDocumentTemplatesQueryResponseStatusConverter.ToBff).ToArray();

        return statuses;
    }
}
