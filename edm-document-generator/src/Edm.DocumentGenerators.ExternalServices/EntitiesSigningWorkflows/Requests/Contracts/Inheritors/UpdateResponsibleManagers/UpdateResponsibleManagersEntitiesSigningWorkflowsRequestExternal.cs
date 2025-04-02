using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateResponsibleManagers;

public sealed class UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternal : EntitiesSigningWorkflowsRequestExternal
{
    public UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternal(
        Document document,
        Id<User> responsibleManagerId)
        : base(document)
    {
        ResponsibleManagerId = responsibleManagerId;
    }

    public Id<User> ResponsibleManagerId { get; }
}
