using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts.Bare;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Update.Contracts.Bare;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Update;

internal static class UpdateDocumentTemplateCommandConverter
{
    internal static UpdateDocumentTemplateCommandInternal ToInternal(UpdateDocumentTemplateCommand request)
    {
        DocumentTemplateBareInternal template = DocumentTemplateBareDtoConverter.ToInternal(request.Template);

        Id<UserInternal> currentUser = IdConverterFrom<UserInternal>.FromString(request.CurrentUser);

        var result = new UpdateDocumentTemplateCommandInternal(template, currentUser);

        return result;
    }
}
