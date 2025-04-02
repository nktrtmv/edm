using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update;

public sealed class UpdateDocumentTemplateService(
    DocumentTemplateService.DocumentTemplateServiceClient serviceClient,
    IRoleAdapter roleAdapter) : DocumentTemplateServiceClientBase(serviceClient)
{
    public async Task<UpdateDocumentTemplateCommandBffResponse> Update(
        UpdateDocumentTemplateCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var roles = await roleAdapter.GetDomainRoles(command.Template.DomainId, cancellationToken);
        var request = UpdateDocumentTemplateCommandBffConverter.ToDto(roles, command, user.Id);

        await DocumentTemplateServiceClient.UpdateAsync(request, cancellationToken: cancellationToken);

        return new UpdateDocumentTemplateCommandBffResponse();
    }
}
