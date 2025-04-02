using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.ChiefApprovals;

public sealed class ChiefApprovalStageBff
{
    public required bool IsRequired { get; init; }
    public required EntityConditionBff Condition { get; init; }
}
