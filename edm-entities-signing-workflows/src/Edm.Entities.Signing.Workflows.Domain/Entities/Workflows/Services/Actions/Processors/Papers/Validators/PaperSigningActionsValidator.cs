using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Papers.Validators;

internal static class PaperSigningActionsValidator
{
    private static readonly Dictionary<SigningActionType, Statuses> ValidStatuses = new Dictionary<SigningActionType, Statuses>
    {
        { SigningActionType.SendToContractor, new Statuses(SigningStageStatus.InProgress, SigningStageStatus.NotStarted) },
        { SigningActionType.Cancel, new Statuses(SigningStageStatus.InProgress, SigningStageStatus.NotStarted) },
        { SigningActionType.ReturnToRework, new Statuses(SigningStageStatus.InProgress, SigningStageStatus.NotStarted) },
        { SigningActionType.WithdrawBySelf, new Statuses(SigningStageStatus.InProgress, SigningStageStatus.NotStarted) },
        { SigningActionType.PutIntoEffect, new Statuses(SigningStageStatus.Signed, SigningStageStatus.InProgress) },
        { SigningActionType.WithdrawByContractor, new Statuses(SigningStageStatus.Signed, SigningStageStatus.InProgress) }
    };

    internal static void Validate(SigningWorkflow workflow, SigningActionType action)
    {
        Statuses? validStatuses = ValidStatuses.GetValueOrDefault(action);

        if (validStatuses is null)
        {
            throw new ApplicationException($"Unexpected workflow ({workflow}) action ({action}).");
        }

        SigningStagesHaveValidStatusesValidator.ValidateStageOfCertainTypeInCertainStatus(workflow, SigningPartyType.Self, validStatuses.SelfStageStatus);

        SigningStagesHaveValidStatusesValidator.ValidateStageOfCertainTypeInCertainStatus(workflow, SigningPartyType.Contractor, validStatuses.ContractorStageStatus);
    }

    private sealed record Statuses(SigningStageStatus SelfStageStatus, SigningStageStatus ContractorStageStatus);
}
