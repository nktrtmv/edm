using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow;

internal static class CreateWorkflowEntitiesApprovalWorkflowsRequestExternalConverter
{
    internal static CreateWorkflowEntitiesApprovalWorkflowsRequestExternal FromDomain(
        CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequestExternal(
            document,
            applicationEvent.Parameters,
            applicationEvent.Options,
            applicationEvent.CurrentUserId,
            applicationEvent.FindRouteResponse!);

        return result;
    }
}
