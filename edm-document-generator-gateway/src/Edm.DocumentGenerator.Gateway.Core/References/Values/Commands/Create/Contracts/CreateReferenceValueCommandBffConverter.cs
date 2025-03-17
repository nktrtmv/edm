using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create.Contracts;

internal static class CreateReferenceValueCommandBffConverter
{
    public static CreateDocumentReferenceValueCommand ToDto(CreateReferenceValueCommandBff request, UserBff user)
    {
        var value = CreateDocumentReferenceValueConverter.ToDto(request);

        var result = new CreateDocumentReferenceValueCommand
        {
            Value = value,
            CurrentUserId = user.Id
        };

        return result;
    }
}
