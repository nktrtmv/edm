using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Backlogs.Validators;

internal static class DocumentBacklogStatusExistsAtMostOnceValidator
{
    internal static void Validate(DocumentStatus[] backlogStatuses)
    {
        int backlogStatusesCount = backlogStatuses.Length;

        if (backlogStatusesCount > 1)
        {
            throw new BusinessLogicApplicationException($"There shall be at most one backlog status but {backlogStatusesCount} were found.");
        }
    }
}
