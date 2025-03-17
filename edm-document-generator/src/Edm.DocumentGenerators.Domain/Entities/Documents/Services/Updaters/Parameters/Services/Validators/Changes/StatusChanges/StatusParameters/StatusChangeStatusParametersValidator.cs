using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.StatusParameters.MasterStage;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.StatusParameters;

internal static class StatusChangeStatusParametersValidator
{
    internal static void Validate(DocumentStatusTransition transition, Document document)
    {
        StatusChangeMasterStageStatusParametersValidator.Validate(transition, document);
    }
}
