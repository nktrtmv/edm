using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateDocumentAuthor;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateOwners;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.UpdateDocumentAuthor;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.UpdateOwners;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values;

internal static class EntitiesApprovalWorkflowsRequestsValueConverter
{
    internal static EntitiesApprovalWorkflowsRequestsValue FromExternal(EntitiesApprovalWorkflowsRequestExternal request)
    {
        var result = new EntitiesApprovalWorkflowsRequestsValue();

        switch (request)
        {
            case CreateWorkflowEntitiesApprovalWorkflowsRequestExternal r:
                result.AsCreateWorkflow = CreateWorkflowEntitiesApprovalWorkflowsRequestConverter.FromExternal(r);

                break;

            case UpdateOwnersEntitiesApprovalWorkflowsRequestExternal r:
                result.AsUpdateOwners = UpdateOwnersEntitiesApprovalWorkflowsRequestConverter.FromExternal(r);

                break;

            case UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestExternal r:
                result.AsUpdateDocumentAuthor = UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestConverter.FromExternal(r);

                break;

            default:
                throw new ArgumentTypeOutOfRangeException(request);
        }

        return result;
    }
}
