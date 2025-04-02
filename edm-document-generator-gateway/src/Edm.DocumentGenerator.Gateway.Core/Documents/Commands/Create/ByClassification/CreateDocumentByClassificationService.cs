using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification;

public sealed class CreateDocumentByClassificationService(DocumentsService.DocumentsServiceClient documentsServiceClient)
{
    public async Task<CreateByClassificationCommandBffResponse> Create(
        CreateByClassificationCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request = CreateByClassificationCommandBffConverter.ToDto(command, user);

        var response = await documentsServiceClient.CreateByClassificationAsync(request, cancellationToken: cancellationToken);

        var result = CreateByClassificationCommandBffResponseConverter.FromDto(response);

        return result;
    }
}
