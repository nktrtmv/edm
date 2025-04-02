using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Create.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Create;

internal static class CreateDocumentTemplateCommandConverter
{
    internal static CreateDocumentTemplateCommandInternal ToInternal(CreateDocumentTemplateCommand request)
    {
        var result = new CreateDocumentTemplateCommandInternal(request.DomainId, request.TemplateId, request.Name, request.SystemName, request.CurrentUser);

        return result;
    }
}
