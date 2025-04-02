using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States;

public sealed class SigningWorkflowStageStateExternal
{
    public SigningWorkflowStageStateExternal(SigningWorkflowStageStatusExternal status, DateTime statusChangedAt)
    {
        Status = status;
        StatusChangedAt = statusChangedAt;
    }

    public SigningWorkflowStageStatusExternal Status { get; }
    public DateTime StatusChangedAt { get; }
}
