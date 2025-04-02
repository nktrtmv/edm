using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators.WorkflowStatuses;

internal static class ElectronicSigningEventWorkflowStatusIsValidValidator
{
    private static readonly SigningStatus[] ValidStatuses =
    {
        SigningStatus.InProgress,
        SigningStatus.Completed
    };

    internal static void Validate(SigningWorkflow workflow)
    {
        if (ValidStatuses.Contains(workflow.State.Status))
        {
            return;
        }

        throw new ApplicationException($"Workflow ({workflow}) has invalid status for document status changed event.");
    }
}
