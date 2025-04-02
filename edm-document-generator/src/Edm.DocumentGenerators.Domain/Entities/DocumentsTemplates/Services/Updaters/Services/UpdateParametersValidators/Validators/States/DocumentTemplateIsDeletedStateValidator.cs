using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.States;

internal static class DocumentTemplateIsDeletedStateValidator
{
    internal static void Validate(DocumentTemplate template)
    {
        if (template.IsDeleted)
        {
            throw new BusinessLogicApplicationException($"Template (id {template.Id}) has been deleted and cannot be modified");
        }
    }
}
