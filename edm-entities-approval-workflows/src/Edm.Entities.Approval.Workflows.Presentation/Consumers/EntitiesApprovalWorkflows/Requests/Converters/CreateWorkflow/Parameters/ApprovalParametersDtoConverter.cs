using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.Entities;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.Info;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.Options;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Info;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Options;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters;

internal static class ApprovalParametersDtoConverter
{
    internal static ApprovalParametersInternal ToInternal(CreateWorkflowEntitiesApprovalWorkflowsRequest request, ApprovalRuleKeyInternal approvalRuleKey)
    {
        ApprovalEntityInternal entity = ApprovalEntityDtoConverter.ToInternal(request.Parameters.Entity);

        ApprovalInfoInternal info = ApprovalInfoDtoConverter.ToInternal(request.Parameters.Info);

        ApprovalOptionsInternal options = ApprovalOptionsDtoConverter.ToInternal(request.Parameters.Options);

        Id<EmployeeInternal> ownerId = request.Parameters.Info.OwnersIds.Select(IdConverterFrom<EmployeeInternal>.FromString).Single();

        Id<EmployeeInternal>? documentAuthorId = string.IsNullOrWhiteSpace(request.Parameters.Info.DocumentAuthorId)
            ? null
            : IdConverterFrom<EmployeeInternal>.FromString(request.Parameters.Info.DocumentAuthorId);

        UtcDateTime<ApprovalRouteInternal>? routeUpdatedDate = NullableConverter.Convert(
            request.FindRouteResponse.Route.UpdatedDate,
            UtcDateTimeConverterFrom<ApprovalRouteInternal>.FromTimestamp);

        var result = new ApprovalParametersInternal(entity, info, options, approvalRuleKey, ownerId, documentAuthorId, routeUpdatedDate);

        return result;
    }
}
