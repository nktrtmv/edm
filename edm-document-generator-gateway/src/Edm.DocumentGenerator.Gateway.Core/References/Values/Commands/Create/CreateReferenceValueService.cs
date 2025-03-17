using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create;

public sealed class CreateReferenceValueService(ReferencesService.ReferencesServiceClient documentReferencesClient)
{
    public async Task<CreateReferenceValueCommandResponseBff> Create(CreateReferenceValueCommandBff request, UserBff user, CancellationToken cancellationToken)
    {
        var command = CreateReferenceValueCommandBffConverter.ToDto(request, user);

        var response = await documentReferencesClient.CreateReferenceValueAsync(command, cancellationToken: cancellationToken);

        var result = CreateReferenceValueCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
