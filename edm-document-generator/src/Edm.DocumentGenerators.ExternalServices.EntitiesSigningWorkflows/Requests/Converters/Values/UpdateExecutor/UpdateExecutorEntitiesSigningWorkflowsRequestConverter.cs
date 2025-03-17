using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateExecutor;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.UpdateExecutor;

internal static class UpdateExecutorEntitiesSigningWorkflowsRequestConverter
{
    internal static EntitiesSigningWorkflowsRequestsValue FromExternal(UpdateExecutorEntitiesSigningWorkflowsRequestExternal request)
    {
        DocumentSigningWorkflow? workflow = request.Document.SigningData.Workflows.Last();

        var workflowId = IdConverterTo.ToString(workflow.Id);

        var executorId = IdConverterTo.ToString(request.ExecutorId);

        var updateExecutors = new UpdateExecutorsEntitiesSigningWorkflowRequest
        {
            WorkflowId = workflowId,
            ExecutorId = executorId
        };

        var result = new EntitiesSigningWorkflowsRequestsValue
        {
            DomainId = request.Document.DomainId.Value,
            UpdateExecutors = updateExecutors
        };

        return result;
    }
}
