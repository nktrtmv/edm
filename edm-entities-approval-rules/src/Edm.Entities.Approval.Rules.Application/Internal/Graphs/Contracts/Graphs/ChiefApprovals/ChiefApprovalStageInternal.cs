using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.ChiefApprovals;

public sealed record ChiefApprovalStageInternal(bool IsRequired, EntityConditionInternal Condition);
