using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateExecutor;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateExecutor;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters.UpdateExecutor;

internal static class UpdateExecutorEntitiesSigningWorkflowsRequestExternalConverter
{
    internal static UpdateExecutorEntitiesSigningWorkflowsRequestExternal FromDomain(
        UpdateExecutorEntitiesSigningWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        var result = new UpdateExecutorEntitiesSigningWorkflowsRequestExternal(document, applicationEvent.ExecutorId);

        return result;
    }
}
