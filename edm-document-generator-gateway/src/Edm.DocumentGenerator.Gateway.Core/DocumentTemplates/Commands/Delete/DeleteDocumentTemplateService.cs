using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Delete.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Delete;

public sealed class DeleteDocumentTemplateService : DocumentTemplateServiceClientBase
{
    public DeleteDocumentTemplateService(DocumentTemplateService.DocumentTemplateServiceClient serviceClient) : base(serviceClient)
    {
    }

    public async Task<DeleteDocumentTemplateCommandBffResponse> Delete(DeleteDocumentTemplateCommandBff command, UserBff user, CancellationToken cancellationToken)
    {
        var request = new DeleteDocumentTemplateCommand
        {
            DomainId = command.DomainId,
            Id = command.Id,
            CurrentUser = user.Id
        };

        await DocumentTemplateServiceClient.DeleteAsync(request, cancellationToken: cancellationToken);

        return new DeleteDocumentTemplateCommandBffResponse();
    }
}
