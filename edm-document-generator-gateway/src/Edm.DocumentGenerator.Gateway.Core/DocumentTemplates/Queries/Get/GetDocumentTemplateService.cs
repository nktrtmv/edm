using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.ExternalServices;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Get;

public sealed class GetDocumentTemplateService(
    DocumentTemplateService.DocumentTemplateServiceClient serviceClient,
    DocumentClassificationService.DocumentClassificationServiceClient documentClassificationServiceClient,
    ReferencesEnricher personsEnricher,
    IRoleAdapter roleAdapter) : DocumentTemplateServiceClientBase(serviceClient)
{
    public async Task<GetDocumentTemplateQueryBffResponse> Get(GetDocumentTemplateQueryBff queryBff, CancellationToken cancellationToken)
    {
        var roles = await roleAdapter.GetDomainRoles(queryBff.DomainId, cancellationToken);
        var query = new GetDocumentTemplateQuery
        {
            Id = queryBff.Id,
            DomainId = queryBff.DomainId
        };

        var response = await DocumentTemplateServiceClient.GetAsync(query, cancellationToken: cancellationToken);

        if (response.Template == null)
        {
            throw new ApplicationException($"Document template with DomainId='{queryBff.DomainId}' and Id='{queryBff.Id}' wasn't found.");
        }

        var classification = queryBff.DomainId != Constants.Contracts
            ? null
            : await documentClassificationServiceClient.GetAsync(
                new GetDocumentClassificationQuery
                {
                    DocumentTemplateId = response.Template.Id
                },
                cancellationToken: cancellationToken);

        var template = DocumentTemplateDetailedBffConverter.ToBff(
            response.Template,
            classification?.DocumentClassification.ClassifierSubset,
            personsEnricher,
            roles);

        await personsEnricher.Enrich(cancellationToken);

        var res = new GetDocumentTemplateQueryBffResponse
        {
            Template = template
        };

        return res;
    }
}
