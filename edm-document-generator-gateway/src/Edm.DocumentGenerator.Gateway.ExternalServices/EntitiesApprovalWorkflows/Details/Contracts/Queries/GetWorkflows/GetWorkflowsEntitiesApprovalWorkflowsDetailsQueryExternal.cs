namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;

public sealed class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal
{
    public GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal(string[] ids)
    {
        Ids = ids;
    }

    public string[] Ids { get; }
}
