using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateExecutor;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.UpdateExecutor;

internal static class UpdateExecutorEntitiesSigningWorkflowsRequestDbConverter
{
    internal static UpdateExecutorEntitiesSigningWorkflowsRequestDb FromDomain(UpdateExecutorEntitiesSigningWorkflowsRequestDocumentApplicationEvent request)
    {
        var executorId = IdConverterTo.ToString(request.ExecutorId);

        var result = new UpdateExecutorEntitiesSigningWorkflowsRequestDb
        {
            ExecutorId = executorId
        };

        return result;
    }

    internal static UpdateExecutorEntitiesSigningWorkflowsRequestDocumentApplicationEvent ToDomain(UpdateExecutorEntitiesSigningWorkflowsRequestDb request)
    {
        Id<User> executorId = IdConverterFrom<User>.FromString(request.ExecutorId);

        var result = new UpdateExecutorEntitiesSigningWorkflowsRequestDocumentApplicationEvent(executorId);

        return result;
    }
}
