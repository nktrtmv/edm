using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateDocumentAuthor;

public sealed class UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestExternal(Document document, Id<User> documentAuthorId)
    : EntitiesApprovalWorkflowsRequestExternal(document)
{
    public Id<User> DocumentAuthorId { get; } = documentAuthorId;
}
