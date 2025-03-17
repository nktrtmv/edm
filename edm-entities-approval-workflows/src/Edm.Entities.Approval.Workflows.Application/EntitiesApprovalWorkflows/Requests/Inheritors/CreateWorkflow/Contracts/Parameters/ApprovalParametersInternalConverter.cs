using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Info;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Options;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.Markers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Info;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Options;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;

internal static class ApprovalWorkflowParametersInternalConverter
{
    internal static ApprovalWorkflowParameters ToDomain(CreateWorkflowEntitiesApprovalWorkflowsRequestInternal request)
    {
        ApprovalWorkflowEntity entity = ApprovalWorkflowEntityInternalConverter.ToDomain(request.Parameters.Entity);

        ApprovalWorkflowInfo info = ApprovalWorkflowInfoInternalConverter.ToDomain(request.Parameters.Info);

        ApprovalWorkflowOptions options = ApprovalWorkflowOptionsInternalConverter.ToDomain(request.Parameters.Options);

        ApprovalRuleKey approvalRuleKey = ApprovalRuleKeyInternalConverter.ToDomain(request.Parameters.ApprovalRuleKey);

        UtcDateTime<ApprovalRoute>? routeUpdatedDate =
            NullableConverter.Convert(request.Parameters.RouteUpdatedDate, UtcDateTimeConverterFrom<ApprovalRoute>.From);

        ApprovalWorkflowParameters result = ApprovalWorkflowParametersFactory.CreateFrom(entity, info, options, approvalRuleKey, routeUpdatedDate);

        return result;
    }
}
