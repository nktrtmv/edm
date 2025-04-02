using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateDocumentAuthor;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.UpdateDocumentAuthor;

internal static class UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDbConverter
{
    internal static UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDb FromDomain(
        UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentApplicationEvent request)
    {
        var documentAuthorId = IdConverterTo.ToString(request.DocumentAuthorId);

        var result = new UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDb
        {
            DocumentAuthorId = documentAuthorId
        };

        return result;
    }

    internal static UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentApplicationEvent ToDomain(UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDb request)
    {
        Id<User> documentAuthorId = IdConverterFrom<User>.FromString(request.DocumentAuthorId);

        var result = new UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(documentAuthorId);

        return result;
    }
}
