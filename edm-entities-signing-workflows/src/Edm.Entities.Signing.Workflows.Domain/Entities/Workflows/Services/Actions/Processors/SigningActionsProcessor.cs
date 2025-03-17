using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Electronics;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Papers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators.AvailableActions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendContractorSigned;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendDocumentsToEdx;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendSelfSigned;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors;

public static class SigningActionsProcessor
{
    public static void Cancel(SigningActionContext context, string completionComment)
    {
        Process(context, SigningActionType.Cancel, SigningStageStatus.Cancelled, completionComment);
    }

    public static void PutIntoEffect(SigningActionContext context)
    {
        Process(context, SigningActionType.PutIntoEffect, SigningStageStatus.Signed);
    }

    public static void ReturnToRework(SigningActionContext context, string completionComment)
    {
        Process(context, SigningActionType.ReturnToRework, SigningStageStatus.ReturnedToRework, completionComment);
    }

    public static void SendToContractor(SigningActionContext context)
    {
        Process(context, SigningActionType.SendToContractor, SigningStageStatus.Signed);
    }

    public static void Sign(SigningActionContext context, Dictionary<Id<Attachment>, Id<Attachment>> documentsWithSignatures)
    {
        Process(context, SigningActionType.Sign, SigningStageStatus.Signed);

        ElectronicDetailsUpdater.Update(context, documentsWithSignatures);

        context.Workflow.ApplicationEvents.Add(SendDocumentsToEdxSigningApplicationEvent.Instance);
    }

    public static void WithdrawByContractor(SigningActionContext context, string completionComment)
    {
        Process(context, SigningActionType.WithdrawByContractor, SigningStageStatus.Withdrawn, completionComment);
    }

    public static void WithdrawBySelf(SigningActionContext context, string completionComment)
    {
        Process(context, SigningActionType.WithdrawBySelf, SigningStageStatus.Withdrawn, completionComment);
    }

    private static void Process(
        SigningActionContext context,
        SigningActionType action,
        SigningStageStatus status,
        string? completionComment = null)
    {
        SigningActionIsAvailableValidator.Validate(context, action);

        SigningStatus workflowStatusBefore = context.Workflow.State.Status;

        SigningStage selfStage = context.Workflow.State.Stages.Single(s => s.Party.Type == SigningPartyType.Self);

        SigningStageStatus selfStageStatusBefore = selfStage.Status;

        SigningStage contractorStage = context.Workflow.State.Stages.Single(s => s.Party.Type == SigningPartyType.Contractor);

        SigningStageStatus contractorStageStatusBefore = contractorStage.Status;

        bool isPaperSigning = context.Workflow.Parameters.ElectronicDetails is null;

        if (isPaperSigning)
        {
            PaperSigningActionsProcessor.Process(context, action, status, completionComment);
        }
        else
        {
            ElectronicSigningActionsProcessor.Process(context, status, completionComment);
        }

        TryAddWorkflowCompletedSigningApplicationEvent(context.Workflow, workflowStatusBefore, context.CurrentUserId);

        TryAddSendSignedSigningApplicationEvent(context.Workflow, selfStageStatusBefore, selfStage.Status, SendSelfSignedSigningApplicationEvent.Instance);

        TryAddSendSignedSigningApplicationEvent(
            context.Workflow,
            contractorStageStatusBefore,
            contractorStage.Status,
            SendContractorSignedSigningApplicationEvent.Instance);
    }

    private static void TryAddWorkflowCompletedSigningApplicationEvent(SigningWorkflow workflow, SigningStatus workflowStatusBefore, Id<User> currentUserId)
    {
        bool isStatusChanged = workflow.State.Status != workflowStatusBefore;

        bool isStageCompleted = workflow.State.Status is SigningStatus.Completed;

        if (isStatusChanged && isStageCompleted)
        {
            SendWorkflowCompletedSigningApplicationEvent applicationEvent =
                SendWorkflowCompletedSigningApplicationEventFactory.CreateFrom(workflow, currentUserId);

            workflow.ApplicationEvents.Add(applicationEvent);
        }
    }

    private static void TryAddSendSignedSigningApplicationEvent(
        SigningWorkflow workflow,
        SigningStageStatus stageStatusBefore,
        SigningStageStatus stageStatusAfter,
        SigningApplicationEvent applicationEvent)
    {
        bool isStatusChanged = stageStatusAfter != stageStatusBefore;

        bool isStageSigned = stageStatusAfter is SigningStageStatus.Signed;

        if (isStatusChanged && isStageSigned)
        {
            workflow.ApplicationEvents.Add(applicationEvent);
        }
    }
}
