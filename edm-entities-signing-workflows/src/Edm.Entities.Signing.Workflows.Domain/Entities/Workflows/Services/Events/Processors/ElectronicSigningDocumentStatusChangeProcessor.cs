using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Updaters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Updaters.WorkflowsStagesStatuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors;

public static class ElectronicSigningDocumentStatusChangeProcessor
{
    public static void Process(SigningWorkflow workflow, SigningStageStatus status, SigningDocument[] documents, params SigningArchive[] archives)
    {
        ElectronicSigningDocumentStatusChangeEventValidator.Validate(workflow, status);

        ElectronicSigningDetailsUpdater.Update(workflow.Parameters.ElectronicDetails!, documents, archives);

        if (workflow.State.Status != SigningStatus.InProgress)
        {
            return;
        }

        SigningStage stage = workflow.State.Stages.Single(s => s.Party.Type == SigningPartyType.Contractor);

        ElectronicSigningWorkflowStageStatusUpdater.Update(stage, status);
    }
}
