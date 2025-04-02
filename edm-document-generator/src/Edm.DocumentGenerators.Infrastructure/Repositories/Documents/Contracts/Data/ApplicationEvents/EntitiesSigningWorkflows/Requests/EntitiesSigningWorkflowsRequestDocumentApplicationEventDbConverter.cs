using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateExecutor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateResponsibleManagers;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.UpdateExecutor;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.UpdateResponsibleManagers;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests;

internal static class EntitiesSigningWorkflowsRequestDocumentApplicationEventDbConverter
{
    internal static EntitiesSigningWorkflowsRequestDocumentApplicationEventDb FromDomain(EntitiesSigningWorkflowsRequestDocumentApplicationEvent applicationEvent)
    {
        var result = new EntitiesSigningWorkflowsRequestDocumentApplicationEventDb();

        switch (applicationEvent)
        {
            case CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent e:
                result.AsCreateWorkflow = CreateWorkflowEntitiesSigningWorkflowsRequestDbConverter.FromDomain(e);

                break;

            case UpdateExecutorEntitiesSigningWorkflowsRequestDocumentApplicationEvent e:
                result.AsUpdateExecutor = UpdateExecutorEntitiesSigningWorkflowsRequestDbConverter.FromDomain(e);

                break;

            case UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentApplicationEvent e:
                result.AsResponsibleManager = UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDbConverter.FromDomain(e);

                break;

            default:
                throw new ArgumentTypeOutOfRangeException(applicationEvent);
        }

        return result;
    }

    internal static EntitiesSigningWorkflowsRequestDocumentApplicationEvent ToDomain(EntitiesSigningWorkflowsRequestDocumentApplicationEventDb applicationEvent)
    {
        EntitiesSigningWorkflowsRequestDocumentApplicationEvent result = applicationEvent.RequestCase switch
        {
            EntitiesSigningWorkflowsRequestDocumentApplicationEventDb.RequestOneofCase.AsCreateWorkflow =>
                CreateWorkflowEntitiesSigningWorkflowsRequestDbConverter.ToDomain(applicationEvent.AsCreateWorkflow),

            EntitiesSigningWorkflowsRequestDocumentApplicationEventDb.RequestOneofCase.AsUpdateExecutor =>
                UpdateExecutorEntitiesSigningWorkflowsRequestDbConverter.ToDomain(applicationEvent.AsUpdateExecutor),

            EntitiesSigningWorkflowsRequestDocumentApplicationEventDb.RequestOneofCase.AsResponsibleManager =>
                UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDbConverter.ToDomain(applicationEvent.AsResponsibleManager),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
