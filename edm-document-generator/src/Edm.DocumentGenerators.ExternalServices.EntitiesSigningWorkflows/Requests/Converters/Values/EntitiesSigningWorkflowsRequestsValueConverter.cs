using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateExecutor;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateResponsibleManagers;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.UpdateExecutor;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.UpdateResponsibleManagers;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values;

internal static class EntitiesSigningWorkflowsRequestsValueConverter
{
    internal static EntitiesSigningWorkflowsRequestsValue FromExternal(EntitiesSigningWorkflowsRequestExternal request)
    {
        EntitiesSigningWorkflowsRequestsValue? result = request switch
        {
            CreateWorkflowEntitiesSigningWorkflowsRequestExternal r =>
                CreateWorkflowEntitiesSigningWorkflowsRequestConverter.FromExternal(r),

            UpdateExecutorEntitiesSigningWorkflowsRequestExternal r =>
                UpdateExecutorEntitiesSigningWorkflowsRequestConverter.FromExternal(r),

            UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternal r =>
                UpdateResponsibleManagerEntitiesSigningWorkflowsRequestConverter.FromExternal(r),

            _ => throw new ArgumentTypeOutOfRangeException(request)
        };

        return result;
    }
}
