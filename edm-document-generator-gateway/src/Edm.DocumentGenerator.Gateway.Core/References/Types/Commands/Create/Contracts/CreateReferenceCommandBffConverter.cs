using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create.Contracts;

internal static class CreateReferenceCommandBffConverter
{
    public static CreateDocumentReferenceTypeCommand ToDto(CreateReferenceCommandBff request, UserBff user)
    {
        var type = CreateDocumentReferenceTypeConverter.ToDto(request);

        var result = new CreateDocumentReferenceTypeCommand
        {
            Type = type,
            CurrentUserId = user.Id
        };

        return result;
    }
}
