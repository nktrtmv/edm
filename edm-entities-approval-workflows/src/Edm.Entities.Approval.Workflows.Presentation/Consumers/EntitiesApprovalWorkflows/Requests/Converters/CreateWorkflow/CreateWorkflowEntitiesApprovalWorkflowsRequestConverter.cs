using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow;

internal static class CreateWorkflowEntitiesApprovalWorkflowsRequestConverter
{
    internal static CreateWorkflowEntitiesApprovalWorkflowsRequestInternal ToInternal(CreateWorkflowEntitiesApprovalWorkflowsRequest request)
    {
        var workflowId =
            IdConverterFrom<ApprovalWorkflowInternal>.FromString(request.WorkflowId);

        var route =
            ApprovalRouteDtoConverter.ToInternal(request.FindRouteResponse.Route);

        var approvalRuleKey =
            ExternalApprovalRuleKeyDtoConverter.ToInternal(request.FindRouteResponse!.ApprovalRuleKey);

        var parameters = ApprovalParametersDtoConverter.ToInternal(request, approvalRuleKey);

        Id<EmployeeInternal> currentUserId = IdConverterFrom<EmployeeInternal>.FromString(request.CurrentUserId);

        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequestInternal(workflowId, route, parameters, currentUserId);

        return result;
    }
}
