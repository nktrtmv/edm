using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Backlogs.Validators;

internal static class DocumentBacklogIsTheOnlyStatusToComeFromInitialValidator
{
    internal static void Validate(DocumentStatus[] backlogStatuses, DocumentStatusTransition[] transitions)
    {
        if (backlogStatuses.Length != 1)
        {
            return;
        }

        DocumentStatusTransition[] transitionToBacklog = transitions.Where(t => t.To.Type == DocumentStatusType.Backlog).ToArray();

        if (transitionToBacklog.Length != 1)
        {
            throw new BusinessLogicApplicationException(
                $"There shall be the only one transition to backlog status but {transitionToBacklog.Length} transitions were found.");
        }

        DocumentStatusTransitionType transitionTypeToBacklog = transitionToBacklog.Single().Type;

        if (transitionTypeToBacklog != DocumentStatusTransitionType.Manual)
        {
            throw new BusinessLogicApplicationException(
                $"The type of transition from initial status to backlog status shall be '{DocumentStatusTransitionType.Manual}' but now it is '{transitionTypeToBacklog}'.");
        }
    }
}
