using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create;

public sealed class CreateReferenceService(ReferencesService.ReferencesServiceClient documentReferencesClient)
{
    public async Task<CreateReferenceCommandResponseBff> Create(CreateReferenceCommandBff request, UserBff user, CancellationToken cancellationToken)
    {
        var command = CreateReferenceCommandBffConverter.ToDto(request, user);

        var response = await documentReferencesClient.CreateReferenceAsync(command, cancellationToken: cancellationToken);

        var result = CreateReferenceCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
