using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

public sealed class SigningWorkflowExternal
{
    public SigningWorkflowExternal(string id, SigningWorkflowStageExternal[] stages)
    {
        Id = id;
        Stages = stages;
    }

    public string Id { get; }
    public SigningWorkflowStageExternal[] Stages { get; }
}
