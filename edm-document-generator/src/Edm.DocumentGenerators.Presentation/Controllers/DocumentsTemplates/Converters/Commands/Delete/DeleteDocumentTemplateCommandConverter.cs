using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Delete.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Delete;

internal static class DeleteDocumentTemplateCommandConverter
{
    internal static DeleteDocumentTemplateCommandInternal ToInternal(DeleteDocumentTemplateCommand request)
    {
        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(request.DomainId);
        var result = new DeleteDocumentTemplateCommandInternal(domainId, request.Id, request.CurrentUser);

        return result;
    }
}
