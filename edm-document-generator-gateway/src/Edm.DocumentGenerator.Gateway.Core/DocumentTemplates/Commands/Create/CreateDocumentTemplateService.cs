using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Create.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;
using Edm.DocumentGenerator.Gateway.ExternalServices;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Create;

public sealed class CreateDocumentTemplateService(
    DocumentTemplateService.DocumentTemplateServiceClient serviceClient,
    DocumentClassificationService.DocumentClassificationServiceClient documentClassificationServiceClient)
    : DocumentTemplateServiceClientBase(serviceClient)
{
    public async Task<CreateDocumentTemplateCommandBffResponse> Create(CreateDocumentTemplateCommandBff command, UserBff user, CancellationToken cancellationToken)
    {
        var templateId = command.DomainId == Constants.Contracts
            ? await CreateTemplateIdByDocumentConstructorClassification(command, cancellationToken)
            : Guid.NewGuid().ToString();

        var request = new CreateDocumentTemplateCommand
        {
            DomainId = command.DomainId,
            TemplateId = templateId,
            Name = command.Name,
            SystemName = command.SystemName,
            CurrentUser = user.Id
        };

        await DocumentTemplateServiceClient.CreateAsync(request, cancellationToken: cancellationToken);

        var result = new CreateDocumentTemplateCommandBffResponse
        {
            Id = templateId
        };

        return result;
    }

    private async Task<string> CreateTemplateIdByDocumentConstructorClassification(
        CreateDocumentTemplateCommandBff command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command.ClassifierSubset);
        var classifierSubset = DocumentClassifierSubsetBffConverter.FromBff(command.ClassifierSubset);

        var classificationResponse = await documentClassificationServiceClient.CreateAsync(
            new CreateDocumentClassificationCommand
            {
                ClassifierSubset = classifierSubset,
                Name = command.Name
            },
            cancellationToken: cancellationToken);

        return classificationResponse.DocumentTemplateId;
    }
}
