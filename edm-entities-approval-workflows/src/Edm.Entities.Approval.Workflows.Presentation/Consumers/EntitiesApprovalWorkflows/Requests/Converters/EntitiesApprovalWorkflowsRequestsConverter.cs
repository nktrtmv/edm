using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.UpdateDocumentAuthor;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.UpdateOwners;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters;

internal static class EntitiesApprovalWorkflowsRequestsConverter
{
    internal static EntitiesApprovalWorkflowsRequestInternal ToInternal(EntitiesApprovalWorkflowsRequestsValue value)
    {
        EntitiesApprovalWorkflowsRequestInternal result = value.RequestCase switch
        {
            EntitiesApprovalWorkflowsRequestsValue.RequestOneofCase.AsCreateWorkflow =>
                CreateWorkflowEntitiesApprovalWorkflowsRequestConverter.ToInternal(value.AsCreateWorkflow),

            EntitiesApprovalWorkflowsRequestsValue.RequestOneofCase.AsUpdateOwners =>
                UpdateOwnersEntitiesApprovalWorkflowsRequestConverter.ToInternal(value.AsUpdateOwners),

            EntitiesApprovalWorkflowsRequestsValue.RequestOneofCase.AsUpdateDocumentAuthor =>
                UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestConverter.ToInternal(value.AsUpdateDocumentAuthor),

            _ => throw new ArgumentTypeOutOfRangeException(value.RequestCase)
        };

        return result;
    }
}
