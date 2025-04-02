using Edm.DocumentGenerators.Domain.Entities.Documents;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts;

public abstract class EntitiesSigningWorkflowsRequestExternal
{
    protected EntitiesSigningWorkflowsRequestExternal(Document document)
    {
        Document = document;
    }

    public Document Document { get; }
}
