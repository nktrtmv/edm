namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;

public sealed class GetElectronicDetailsSigningWorkflowDetailsQueryExternal
{
    public GetElectronicDetailsSigningWorkflowDetailsQueryExternal(string workflowId)
    {
        WorkflowId = workflowId;
    }

    public string WorkflowId { get; }
}
