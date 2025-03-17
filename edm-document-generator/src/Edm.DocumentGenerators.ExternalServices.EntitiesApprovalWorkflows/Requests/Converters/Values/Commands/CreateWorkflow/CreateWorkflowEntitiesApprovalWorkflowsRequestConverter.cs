using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow;

internal static class CreateWorkflowEntitiesApprovalWorkflowsRequestConverter
{
    internal static CreateWorkflowEntitiesApprovalWorkflowsRequest FromExternal(CreateWorkflowEntitiesApprovalWorkflowsRequestExternal request)
    {
        DocumentApprovalWorkflow workflow = request.Document.ApprovalData.Workflows.Last();

        var workflowId = IdConverterTo.ToString(workflow.Id);

        FindRouteApprovalRulesQueryResponse findRouteResponse = BytesConverterTo.ToDto(request.FindRouteResponse, FindRouteApprovalRulesQueryResponse.Parser);

        ApprovalParametersDto parameters = ApprovalParametersDtoConverter.FromDomain(request);

        var currentUserId = IdConverterTo.ToString(request.CurrentUserId);

        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequest
        {
            WorkflowId = workflowId,
            FindRouteResponse = findRouteResponse,
            Parameters = parameters,
            CurrentUserId = currentUserId
        };

        return result;
    }
}
