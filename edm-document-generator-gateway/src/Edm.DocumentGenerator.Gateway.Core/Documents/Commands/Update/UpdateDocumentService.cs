using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update;

public sealed class UpdateDocumentService(DocumentsService.DocumentsServiceClient documentsServiceClient)
{
    public async Task<UpdateDocumentCommandBffResponse> Update(UpdateDocumentCommandBff request, UserBff user, CancellationToken cancellationToken)
    {
        var command = UpdateDocumentCommandBffConverter.ToDto(request, user.Id);

        await documentsServiceClient.UpdateAsync(command, cancellationToken: cancellationToken);

        return UpdateDocumentCommandBffResponse.Instance;
    }
}
