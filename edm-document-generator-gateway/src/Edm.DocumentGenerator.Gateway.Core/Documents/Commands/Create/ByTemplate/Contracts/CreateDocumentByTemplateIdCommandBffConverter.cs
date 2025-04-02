using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByTemplate.Contracts;

internal static class CreateDocumentByTemplateIdCommandBffConverter
{
    internal static CreateDocumentByTemplateIdCommand ToDto(CreateDocumentByTemplateIdCommandBff command, UserBff user)
    {
        var result = new CreateDocumentByTemplateIdCommand
        {
            DomainId = command.DomainId,
            TemplateId = command.TemplateId,
            CurrentUserId = user.Id
        };

        return result;
    }
}
