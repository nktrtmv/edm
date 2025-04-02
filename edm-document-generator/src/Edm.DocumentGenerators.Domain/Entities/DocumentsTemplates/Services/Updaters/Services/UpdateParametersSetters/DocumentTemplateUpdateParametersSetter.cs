using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersSetters;

internal static class DocumentTemplateUpdateParametersSetter
{
    internal static void Set(DocumentTemplateUpdateParameters parameters, DocumentTemplate template)
    {
        template.SetName(parameters.UpdatedName);
        template.SetStatus(parameters.UpdatedStatus);
        template.SetDocumentPrototype(parameters.UpdatedPrototype);
        template.SetFrontMetadata(parameters.UpdatedFrontMetadata);
    }
}
