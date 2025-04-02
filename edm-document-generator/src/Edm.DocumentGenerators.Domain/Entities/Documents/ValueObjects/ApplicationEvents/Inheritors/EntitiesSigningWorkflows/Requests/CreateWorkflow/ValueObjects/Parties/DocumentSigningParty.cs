using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.
    Parties;

public sealed class DocumentSigningParty
{
    public DocumentSigningParty(DocumentParty party, Id<User> executorId)
    {
        Party = party;
        ExecutorId = executorId;
    }

    public DocumentParty Party { get; }
    public Id<User> ExecutorId { get; }
}
