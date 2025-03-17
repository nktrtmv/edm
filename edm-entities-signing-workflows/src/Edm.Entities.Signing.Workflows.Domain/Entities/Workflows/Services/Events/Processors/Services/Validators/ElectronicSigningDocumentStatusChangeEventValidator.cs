using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators.WorkflowStagesValidator;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators.WorkflowStatuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators.WorkflowTypes;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators;

internal static class ElectronicSigningDocumentStatusChangeEventValidator
{
    internal static void Validate(SigningWorkflow workflow, SigningStageStatus status)
    {
        ElectronicSigningEventWorkflowTypeIsElectronicValidator.Validate(workflow);

        ElectronicSigningEventWorkflowStatusIsValidValidator.Validate(workflow);

        ElectronicSigningEventWorkflowStagesAreValidValidator.Validate(workflow, status);
    }
}
