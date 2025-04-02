using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators;

internal static class SigningStagesHaveValidStatusesValidator
{
    internal static void ValidateStageOfCertainTypeInCertainStatus(SigningWorkflow workflow, SigningPartyType type, params SigningStageStatus[] validStatuses)
    {
        SigningStage? stage = workflow.State.Stages.LastOrDefault(s => s.Party.Type == type);

        if (stage is null)
        {
            throw new ApplicationException($"Required stage ({type}) for workflow ({workflow}) is not found.");
        }

        if (!validStatuses.Contains(stage.Status))
        {
            string validStatusesString = string.Join(",", validStatuses);

            throw new ApplicationException(
                $"Workflow ({workflow}) is in invalid state for electronic status change processing. Valid statuses for stage ({stage}) are: {validStatusesString}.");
        }
    }
}
