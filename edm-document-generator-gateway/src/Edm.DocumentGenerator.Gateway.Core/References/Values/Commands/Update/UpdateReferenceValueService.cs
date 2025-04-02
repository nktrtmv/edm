using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update;

public sealed class UpdateReferenceValueService(ReferencesService.ReferencesServiceClient documentReferenceClient)
{
    public async Task<UpdateReferenceValueCommandResponseBff> Update(UpdateReferenceValueCommandBff request, UserBff user, CancellationToken cancellationToken)
    {
        var command = UpdateReferenceValueCommandBffConverter.ToDto(request, user);

        var response = await documentReferenceClient.UpdateReferenceValueAsync(command, cancellationToken: cancellationToken);

        var result = UpdateReferenceValueCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
