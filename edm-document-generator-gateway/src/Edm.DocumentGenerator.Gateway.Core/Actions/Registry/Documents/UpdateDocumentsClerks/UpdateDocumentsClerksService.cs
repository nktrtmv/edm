using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsClerks.Contracts.Commands;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsClerks;

public sealed class UpdateDocumentsClerksService(DocumentsService.DocumentsServiceClient documents)
{
    public async Task<UpdateDocumentsResponseBff> Update(
        UpdateDocumentsClerksCommandBff commandBff,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var command = UpdateDocumentsClerksCommandBffConverter.ToDto(commandBff, user);

        var response = await documents.DocumentClerkBatchUpdateAsync(command, cancellationToken: cancellationToken);

        var result = UpdateDocumentsResponseBffConverter.FromDto(response);

        return result;
    }
}
