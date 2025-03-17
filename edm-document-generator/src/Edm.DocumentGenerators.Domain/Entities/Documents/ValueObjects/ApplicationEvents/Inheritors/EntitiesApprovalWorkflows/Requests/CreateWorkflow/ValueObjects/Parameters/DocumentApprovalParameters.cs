using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.
    Parameters;

public sealed record DocumentApprovalParameters(string Title, string Description, Id<User> ClerkId, Id<User> DocumentAuthorId);
