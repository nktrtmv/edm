using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get.Contracts;

public sealed record GetApprovalRuleQueryResponseInternal(EntityTypeKeyInternal EntityTypeKey, string DisplayName, bool IsReadonly);
