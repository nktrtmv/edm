using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update;

public sealed class UpdateReferenceService(ReferencesService.ReferencesServiceClient documentReferenceClient)
{
    public async Task<UpdateReferenceCommandResponseBff> Update(UpdateReferenceCommandBff request, UserBff user, CancellationToken cancellationToken)
    {
        var command = UpdateReferenceCommandBffConverter.ToDto(request, user);

        var response = await documentReferenceClient.UpdateReferenceAsync(command, cancellationToken: cancellationToken);

        var result = UpdateReferenceCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
