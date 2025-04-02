using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.Markers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Info;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Options;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;

public sealed class ApprovalWorkflowParameters
{
    public ApprovalWorkflowParameters(
        ApprovalWorkflowEntity entity,
        ApprovalWorkflowInfo info,
        ApprovalWorkflowOptions options,
        ApprovalRuleKey? approvalRuleKey,
        UtcDateTime<ApprovalRoute>? routeUpdatedDate)
    {
        Entity = entity;
        Info = info;
        Options = options;
        ApprovalRuleKey = approvalRuleKey;
        RouteUpdatedDate = routeUpdatedDate;
    }

    public ApprovalWorkflowEntity Entity { get; }
    public ApprovalWorkflowInfo Info { get; }
    public ApprovalWorkflowOptions Options { get; }
    public ApprovalRuleKey? ApprovalRuleKey { get; }
    public UtcDateTime<ApprovalRoute>? RouteUpdatedDate { get; }

    public override string ToString()
    {
        return $"{{ Entity: {Entity}, Info: {Info}, Options: {Options}, ApprovalRuleKey: {ApprovalRuleKey} }}";
    }
}
