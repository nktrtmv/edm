using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;

public sealed class GetWorkflowsSigningWorkflowDetailsQueryResponseExternal
{
    public GetWorkflowsSigningWorkflowDetailsQueryResponseExternal(SigningWorkflowExternal[] workflows)
    {
        Workflows = workflows;
    }

    public SigningWorkflowExternal[] Workflows { get; }
}
