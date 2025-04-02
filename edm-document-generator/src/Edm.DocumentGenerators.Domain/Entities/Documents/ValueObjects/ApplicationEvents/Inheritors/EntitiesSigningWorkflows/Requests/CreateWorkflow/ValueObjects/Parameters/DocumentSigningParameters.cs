using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters.
    Electronics;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.
    Parameters;

public sealed class DocumentSigningParameters
{
    public DocumentSigningParameters(Id<User>? documentClerkId, DocumentSigningElectronicParameters? electronic)
    {
        DocumentClerkId = documentClerkId;
        Electronic = electronic;
    }

    public Id<User>? DocumentClerkId { get; }
    public DocumentSigningElectronicParameters? Electronic { get; }
}
