using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateDocumentAuthor;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateDocumentAuthor;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters.UpdateDocumentAuthor;

internal static class UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestExternalConverter
{
    internal static UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestExternal FromDomain(
        UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        var result = new UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestExternal(document, applicationEvent.DocumentAuthorId);

        return result;
    }
}
