using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Backlogs.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Backlogs;

internal static class DocumentBacklogStatusValidator
{
    internal static void Validate(DocumentStatus[] statuses, DocumentStatusTransition[] transitions)
    {
        DocumentStatus[] backlogStatuses = statuses.Where(s => s.Type == DocumentStatusType.Backlog).ToArray();

        DocumentBacklogStatusExistsAtMostOnceValidator.Validate(backlogStatuses);

        DocumentBacklogIsTheOnlyStatusToComeFromInitialValidator.Validate(backlogStatuses, transitions);
    }
}
