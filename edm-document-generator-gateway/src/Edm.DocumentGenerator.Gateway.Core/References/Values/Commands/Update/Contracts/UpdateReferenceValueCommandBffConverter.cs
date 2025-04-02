using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update.Contracts;

internal static class UpdateReferenceValueCommandBffConverter
{
    public static UpdateDocumentReferenceValueCommand ToDto(UpdateReferenceValueCommandBff request, UserBff user)
    {
        var value = UpdateDocumentReferenceValueConverter.ToDto(request);

        var result = new UpdateDocumentReferenceValueCommand
        {
            Value = value,
            CurrentUserId = user.Id,
            ConcurrencyToken = request.ConcurrencyToken
        };

        return result;
    }
}
