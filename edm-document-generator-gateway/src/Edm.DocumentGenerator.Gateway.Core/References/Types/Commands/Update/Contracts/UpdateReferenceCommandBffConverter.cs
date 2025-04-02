using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update.Contracts;

internal static class UpdateReferenceCommandBffConverter
{
    public static UpdateDocumentReferenceTypeCommand ToDto(UpdateReferenceCommandBff request, UserBff user)
    {
        var reference = UpdateDocumentReferenceTypeConverter.ToDto(request);

        var result = new UpdateDocumentReferenceTypeCommand
        {
            Reference = reference,
            CurrentUserId = user.Id,
            ConcurrencyToken = request.ConcurrencyToken
        };

        return result;
    }
}
