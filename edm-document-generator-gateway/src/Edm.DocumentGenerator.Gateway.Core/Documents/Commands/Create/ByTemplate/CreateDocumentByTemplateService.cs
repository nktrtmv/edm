using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByTemplate.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByTemplate;

public sealed class CreateDocumentByTemplateService(DocumentsService.DocumentsServiceClient documentsServiceClient)
{
    public async Task<CreateDocumentByTemplateIdCommandBffResponse> Create(
        CreateDocumentByTemplateIdCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request = CreateDocumentByTemplateIdCommandBffConverter.ToDto(command, user);

        var response = await documentsServiceClient.CreateByTemplateIdAsync(request, cancellationToken: cancellationToken);

        var result = new CreateDocumentByTemplateIdCommandBffResponse { Id = response.DocumentId };

        return result;
    }
}
