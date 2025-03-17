using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.Markers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Info;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Options;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.Entities;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.Info;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.Options;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters;

internal static class ApprovalWorkflowParametersDbConverter
{
    internal static ApprovalWorkflowParametersDb FromDomain(ApprovalWorkflowParameters parameters)
    {
        WorkflowEntityDb entity = ApprovalWorkflowEntityDbConverter.FromDomain(parameters.Entity);

        ApprovalWorkflowInfoDb info = ApprovalWorkflowInfoDbConverter.FromDomain(parameters.Info);

        ApprovalWorkflowOptionsDb options = ApprovalWorkflowOptionsDbConverter.FromDomain(parameters.Options);

        ApprovalRuleKeyDb? approvalRuleKey = NullableConverter.Convert(parameters.ApprovalRuleKey, ApprovalRuleKeyDbConverter.FromDomain);

        Timestamp? routeUpdatedDate = NullableConverter.Convert(parameters.RouteUpdatedDate, UtcDateTimeConverterTo.ToTimeStamp);

        var result = new ApprovalWorkflowParametersDb
        {
            Entity = entity,
            Info = info,
            Options = options,
            ApprovalRuleKey = approvalRuleKey,
            RouteUpdatedDate = routeUpdatedDate
        };

        return result;
    }

    internal static ApprovalWorkflowParameters ToDomain(ApprovalWorkflowParametersDb parameters)
    {
        ApprovalWorkflowEntity entity = ApprovalWorkflowEntityDbConverter.ToDomain(parameters.Entity);

        ApprovalWorkflowInfo info = ApprovalWorkflowInfoDbConverter.ToDomain(parameters.Info);

        ApprovalWorkflowOptions options = ApprovalWorkflowOptionsDbConverter.ToDomain(parameters.Options);

        ApprovalRuleKey? approvalRuleKey = NullableConverter.Convert(parameters.ApprovalRuleKey, ApprovalRuleKeyDbConverter.ToDomain);

        UtcDateTime<ApprovalRoute>? routeUpdatedDate = NullableConverter.Convert(parameters.RouteUpdatedDate, UtcDateTimeConverterFrom<ApprovalRoute>.FromTimestamp);

        ApprovalWorkflowParameters result = ApprovalWorkflowParametersFactory.CreateFromDb(entity, info, options, approvalRuleKey, routeUpdatedDate);

        return result;
    }
}
