using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters.UpdateDocumentAuthor;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters.UpdateOwners;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateDocumentAuthor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateOwners;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters;

internal static class EntitiesApprovalWorkflowsRequestExternalConverter
{
    internal static EntitiesApprovalWorkflowsRequestExternal FromDomain(
        EntitiesApprovalWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        EntitiesApprovalWorkflowsRequestExternal result = applicationEvent switch
        {
            CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent e =>
                CreateWorkflowEntitiesApprovalWorkflowsRequestExternalConverter.FromDomain(e, document),

            UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent e =>
                UpdateOwnersEntitiesApprovalWorkflowsRequestExternalConverter.FromDomain(e, document),

            UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentApplicationEvent e =>
                UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestExternalConverter.FromDomain(e, document),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
