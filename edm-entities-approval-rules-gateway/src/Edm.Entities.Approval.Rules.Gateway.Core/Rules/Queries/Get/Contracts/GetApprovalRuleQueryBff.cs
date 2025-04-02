using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get.Contracts;

public sealed class GetApprovalRuleQueryBff
{
    public required EntityTypeKeyBff EntityTypeKey { get; init; }
}
