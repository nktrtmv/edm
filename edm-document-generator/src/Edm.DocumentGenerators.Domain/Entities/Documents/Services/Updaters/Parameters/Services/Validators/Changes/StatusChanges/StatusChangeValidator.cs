using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.StatusParameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.TransitionParameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges;

internal static class StatusChangeValidator
{
    internal static void Validate(DocumentStatusChange statusChange, Document document)
    {
        TransitionParametersAreFilledValidator.Validate(statusChange.StatusTransitionParametersValues);

        StatusChangeStatusParametersValidator.Validate(statusChange.Transition, document);
    }
}
