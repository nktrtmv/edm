namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Validators.WorkflowTypes;

internal static class ElectronicSigningEventWorkflowTypeIsElectronicValidator
{
    internal static void Validate(SigningWorkflow workflow)
    {
        if (workflow.Parameters.ElectronicDetails is not null)
        {
            return;
        }

        throw new ApplicationException($"Workflow ({workflow}) has invalid signing type for document status changed event. Electronic signing type is expected.");
    }
}
