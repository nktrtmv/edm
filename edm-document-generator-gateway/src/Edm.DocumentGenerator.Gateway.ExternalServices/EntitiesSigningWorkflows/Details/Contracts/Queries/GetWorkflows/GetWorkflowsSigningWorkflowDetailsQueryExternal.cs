namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;

public sealed class GetWorkflowsSigningWorkflowDetailsQueryExternal
{
    public GetWorkflowsSigningWorkflowDetailsQueryExternal(string[] ids)
    {
        Ids = ids;
    }

    public string[] Ids { get; }
}
