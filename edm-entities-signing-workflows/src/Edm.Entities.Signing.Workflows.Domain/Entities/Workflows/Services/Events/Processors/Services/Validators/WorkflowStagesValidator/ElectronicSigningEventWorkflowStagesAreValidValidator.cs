using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators.WorkflowStagesValidator;

internal static class ElectronicSigningEventWorkflowStagesAreValidValidator
{
    private static readonly SigningStageStatus[] InProgress =
    {
        SigningStageStatus.InProgress
    };

    private static readonly SigningStageStatus[] InProgressOrError =
    {
        SigningStageStatus.InProgress,
        SigningStageStatus.Error
    };

    private static readonly SigningStageStatus[] InProgressOrSigned =
    {
        SigningStageStatus.InProgress,
        SigningStageStatus.Signed
    };

    private static readonly SigningStageStatus[] InProgressOrRejected =
    {
        SigningStageStatus.InProgress,
        SigningStageStatus.Rejected
    };

    private static readonly SigningStageStatus[] InProgressOrSignedOrRevocation =
    {
        SigningStageStatus.InProgress,
        SigningStageStatus.Signed,
        SigningStageStatus.Revocation
    };

    private static readonly SigningStageStatus[] InProgressOrSignedOrRevocationOrRevoked =
    {
        SigningStageStatus.InProgress,
        SigningStageStatus.Signed,
        SigningStageStatus.Revocation,
        SigningStageStatus.Revoked
    };

    private static readonly Dictionary<SigningStageStatus, SigningStageStatus[]> ValidContractorStageStatuses =
        new Dictionary<SigningStageStatus, SigningStageStatus[]>
        {
            { SigningStageStatus.InProgress, InProgress },
            { SigningStageStatus.Error, InProgressOrError },
            { SigningStageStatus.Signed, InProgressOrSigned },
            { SigningStageStatus.Rejected, InProgressOrRejected },
            { SigningStageStatus.Revocation, InProgressOrSignedOrRevocation },
            { SigningStageStatus.Revoked, InProgressOrSignedOrRevocationOrRevoked }
        };

    internal static void Validate(SigningWorkflow workflow, SigningStageStatus status)
    {
        ValidateIncomingStatus(workflow, status);

        ValidateStageOfCertainTypeInCertainStatus(workflow, SigningPartyType.Self, status, SigningStageStatus.Signed);

        SigningStageStatus[] validContractorStageStatuses = ValidContractorStageStatuses[status];

        ValidateStageOfCertainTypeInCertainStatus(workflow, SigningPartyType.Contractor, status, validContractorStageStatuses);
    }

    private static void ValidateStageOfCertainTypeInCertainStatus(
        SigningWorkflow workflow,
        SigningPartyType type,
        SigningStageStatus status,
        params SigningStageStatus[] validStatuses)
    {
        SigningStage stage = workflow.State.Stages.Single(s => s.Party.Type == type);

        if (!validStatuses.Contains(stage.Status))
        {
            string validStatusesString = string.Join(", ", validStatuses);

            throw new ApplicationException(
                $"Workflow ({workflow}) has stage ({stage}) that has invalid status for document status changed event ({status}). Valid statuses are: {validStatusesString}.");
        }
    }

    private static void ValidateIncomingStatus(SigningWorkflow workflow, SigningStageStatus status)
    {
        if (status is
            SigningStageStatus.InProgress or
            SigningStageStatus.Signed or
            SigningStageStatus.Rejected or
            SigningStageStatus.Error or
            SigningStageStatus.Revocation or
            SigningStageStatus.Revoked)
        {
            return;
        }

        throw new ApplicationException($"Unexpected status ({status}) for electronic signing, workflow ({workflow}).");
    }
}
