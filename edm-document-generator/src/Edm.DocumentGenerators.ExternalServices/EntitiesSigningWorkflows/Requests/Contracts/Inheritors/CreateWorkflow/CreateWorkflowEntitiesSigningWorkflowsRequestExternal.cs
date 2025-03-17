using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;

public sealed class CreateWorkflowEntitiesSigningWorkflowsRequestExternal : EntitiesSigningWorkflowsRequestExternal
{
    public CreateWorkflowEntitiesSigningWorkflowsRequestExternal(
        Document document,
        Id<User> currentUserId,
        DocumentSigningParameters parameters,
        DocumentSigningParty[] parties)
        : base(document)
    {
        CurrentUserId = currentUserId;
        Parameters = parameters;
        Parties = parties;
    }

    public Id<User> CurrentUserId { get; }
    public DocumentSigningParameters Parameters { get; }
    public DocumentSigningParty[] Parties { get; }
}
