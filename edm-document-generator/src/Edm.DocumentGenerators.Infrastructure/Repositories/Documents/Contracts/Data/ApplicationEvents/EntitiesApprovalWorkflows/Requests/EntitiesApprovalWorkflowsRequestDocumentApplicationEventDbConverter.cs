using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateDocumentAuthor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateOwners;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.UpdateDocumentAuthor;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.UpdateOwners;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests;

internal static class EntitiesApprovalWorkflowsRequestDocumentApplicationEventDbConverter
{
    internal static EntitiesApprovalWorkflowsRequestDocumentApplicationEventDb FromDomain(EntitiesApprovalWorkflowsRequestDocumentApplicationEvent applicationEvent)
    {
        var result = new EntitiesApprovalWorkflowsRequestDocumentApplicationEventDb();

        switch (applicationEvent)
        {
            case CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent e:
                result.AsCreateWorkflow = CreateWorkflowEntitiesApprovalWorkflowsRequestDbConverter.FromDomain(e);

                break;

            case UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent e:
                result.AsUpdateOwners = UpdateOwnersEntitiesApprovalWorkflowsRequestDbConverter.FromDomain(e);

                break;

            case UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentApplicationEvent e:
                result.AsUpdateDocumentAuthor = UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDbConverter.FromDomain(e);

                break;

            default:
                throw new ArgumentTypeOutOfRangeException(applicationEvent);
        }

        return result;
    }

    internal static EntitiesApprovalWorkflowsRequestDocumentApplicationEvent ToDomain(EntitiesApprovalWorkflowsRequestDocumentApplicationEventDb applicationEvent)
    {
        EntitiesApprovalWorkflowsRequestDocumentApplicationEvent result = applicationEvent.RequestCase switch
        {
            EntitiesApprovalWorkflowsRequestDocumentApplicationEventDb.RequestOneofCase.AsCreateWorkflow =>
                CreateWorkflowEntitiesApprovalWorkflowsRequestDbConverter.ToDomain(applicationEvent.AsCreateWorkflow),

            EntitiesApprovalWorkflowsRequestDocumentApplicationEventDb.RequestOneofCase.AsUpdateOwners =>
                UpdateOwnersEntitiesApprovalWorkflowsRequestDbConverter.ToDomain(applicationEvent.AsUpdateOwners),

            EntitiesApprovalWorkflowsRequestDocumentApplicationEventDb.RequestOneofCase.AsUpdateDocumentAuthor =>
                UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDbConverter.ToDomain(applicationEvent.AsUpdateDocumentAuthor),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
