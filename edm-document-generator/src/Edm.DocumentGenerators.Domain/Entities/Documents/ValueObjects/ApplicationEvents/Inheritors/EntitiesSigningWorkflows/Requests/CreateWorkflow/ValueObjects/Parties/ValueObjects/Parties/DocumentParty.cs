using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties
    .ValueObjects.
    Parties;

public sealed class DocumentParty
{
    public DocumentParty(Id<DocumentParty> id, DocumentPartyType type)
    {
        Id = id;
        Type = type;
    }

    public Id<DocumentParty> Id { get; }
    public DocumentPartyType Type { get; }
}
