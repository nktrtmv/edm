using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.ApprovalParticipantAttributes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Contexts;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersSetters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Services.Updaters;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters;

public static class DocumentTemplateUpdater
{
    public static DocumentTemplateUpdatingContext? Update(DocumentTemplateUpdateParameters parameters)
    {
        ApprovalParticipantAttributesMetadataIdsRestorer.Restore(parameters);

        DocumentTemplateUpdateParametersValidator.Validate(parameters);

        DocumentTemplateUpdatingContext? documentTemplateUpdatingContext =
            DocumentTemplateUpdatingContextPreparer.Prepare(parameters, parameters.Template);

        DocumentTemplateUpdateParametersSetter.Set(parameters, parameters.Template);

        Audit<DocumentTemplate> audit = AuditUpdater.Update(parameters.Template.Audit, parameters.CurrentUserId);

        parameters.Template.SetAudit(audit);
        parameters.Template.SetSystemName(parameters.UpdatedSystemName);

        return documentTemplateUpdatingContext;
    }
}
