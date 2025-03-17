using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters.CreateWorkflow;

internal static class CreateWorkflowEntitiesSigningWorkflowsRequestExternalConverter
{
    internal static CreateWorkflowEntitiesSigningWorkflowsRequestExternal FromDomain(
        CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        var result = new CreateWorkflowEntitiesSigningWorkflowsRequestExternal(
            document,
            applicationEvent.CurrentUserId,
            applicationEvent.Parameters,
            applicationEvent.Parties);

        return result;
    }
}
