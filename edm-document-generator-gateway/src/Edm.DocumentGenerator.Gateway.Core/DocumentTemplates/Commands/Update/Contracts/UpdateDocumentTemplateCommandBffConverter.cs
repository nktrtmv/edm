using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update.Contracts;

public static class UpdateDocumentTemplateCommandBffConverter
{
    public static UpdateDocumentTemplateCommand ToDto(DomainRoles domainRoles, UpdateDocumentTemplateCommandBff commandBff, string userId)
    {
        var template = DocumentTemplateBareBffConverter.ToDto(domainRoles, commandBff.Template);

        var command = new UpdateDocumentTemplateCommand
        {
            Template = template,
            CurrentUser = userId
        };

        return command;
    }
}
