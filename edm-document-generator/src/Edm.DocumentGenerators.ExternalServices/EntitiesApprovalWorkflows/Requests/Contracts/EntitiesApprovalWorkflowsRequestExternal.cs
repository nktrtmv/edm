using Edm.DocumentGenerators.Domain.Entities.Documents;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts;

public abstract class EntitiesApprovalWorkflowsRequestExternal
{
    protected EntitiesApprovalWorkflowsRequestExternal(Document document)
    {
        Document = document;
    }

    public Document Document { get; }
}
