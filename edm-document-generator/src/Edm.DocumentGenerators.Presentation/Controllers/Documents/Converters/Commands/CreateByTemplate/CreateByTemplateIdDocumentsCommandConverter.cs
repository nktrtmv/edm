using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByTemplate.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.CreateByTemplate;

internal static class CreateByTemplateIdDocumentsCommandConverter
{
    internal static CreateDocumentByTemplateIdCommandInternal ToInternal(CreateDocumentByTemplateIdCommand command)
    {
        string? domainId = DomainIdHelper.GetDomainIdOrSetDefault(command.DomainId);
        var result = new CreateDocumentByTemplateIdCommandInternal(domainId, command.TemplateId, command.CurrentUserId);

        return result;
    }
}
