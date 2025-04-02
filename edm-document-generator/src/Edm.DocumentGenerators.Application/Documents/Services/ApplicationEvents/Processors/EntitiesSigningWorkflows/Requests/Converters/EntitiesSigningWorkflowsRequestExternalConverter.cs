using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters.CreateWorkflow;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters.UpdateExecutor;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters.UpdateResponsibleManager;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateExecutor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateResponsibleManagers;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters;

internal static class EntitiesSigningWorkflowsRequestExternalConverter
{
    internal static EntitiesSigningWorkflowsRequestExternal FromDomain(
        EntitiesSigningWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        EntitiesSigningWorkflowsRequestExternal result = applicationEvent switch
        {
            CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent e =>
                CreateWorkflowEntitiesSigningWorkflowsRequestExternalConverter.FromDomain(e, document),

            UpdateExecutorEntitiesSigningWorkflowsRequestDocumentApplicationEvent e =>
                UpdateExecutorEntitiesSigningWorkflowsRequestExternalConverter.FromDomain(e, document),

            UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentApplicationEvent e =>
                UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternalConverter.FromDomain(e, document),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
