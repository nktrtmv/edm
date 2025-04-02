using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules.Types;

internal static class EntityTypeSlimInternalConverter
{
    internal static GetAllApprovalRulesQueryResponseEntityTypeInternal FromDomain(ApprovalRule rule)
    {
        EntityTypeKeyInternal key = EntityTypeKeyInternalConverter.FromDomain(rule.EntityType.Key);

        var result = new GetAllApprovalRulesQueryResponseEntityTypeInternal(key, rule.EntityType.DisplayName, rule.IsActive);

        return result;
    }
}
