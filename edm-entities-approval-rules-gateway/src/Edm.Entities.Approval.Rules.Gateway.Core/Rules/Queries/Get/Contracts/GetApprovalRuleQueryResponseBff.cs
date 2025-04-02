using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get.Contracts;

public sealed class GetApprovalRuleQueryResponseBff
{
    public required EntityTypeKeyBff Key { get; init; }
    public required string DisplayName { get; init; }
    public required bool IsReadonly { get; init; }
}
