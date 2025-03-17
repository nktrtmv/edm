using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateOwners;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateOwners;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters.UpdateOwners;

internal static class UpdateOwnersEntitiesApprovalWorkflowsRequestExternalConverter
{
    internal static UpdateOwnersEntitiesApprovalWorkflowsRequestExternal FromDomain(
        UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        var result = new UpdateOwnersEntitiesApprovalWorkflowsRequestExternal(document, applicationEvent.OwnerId);

        return result;
    }
}
