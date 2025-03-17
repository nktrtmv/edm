using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.StatusParameters.AutoStatuses;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.StatusParameters.StatusesRelations;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.StatusParameters;

internal static class DocumentStatusesParametersValidator
{
    internal static void Validate(DocumentStatus[] statuses, DocumentPrototype prototype)
    {
        foreach (DocumentStatus? status in statuses)
        {
            DocumentAutoStatusesParametersValidator.Validate(status);

            DocumentStatusesRelationsValidator.Validate(status, statuses, prototype);
        }
    }
}
