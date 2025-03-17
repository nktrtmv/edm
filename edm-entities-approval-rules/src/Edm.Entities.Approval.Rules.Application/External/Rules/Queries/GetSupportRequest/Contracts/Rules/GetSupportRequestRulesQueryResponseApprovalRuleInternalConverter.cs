using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest.Contracts.Rules;

internal static class GetSupportRequestRulesQueryResponseApprovalRuleInternalConverter
{
    internal static GetSupportRequestRulesQueryResponseApprovalRuleInternal FromDomain(ApprovalRule rule)
    {
        Id<EntityTypeInternal> entityTypeId = IdConverterFrom<EntityTypeInternal>.From(rule.EntityType.Key.EntityTypeId);

        DateTime entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityTypeInternal>.From(rule.EntityType.Key.EntityTypeUpdatedDate).Value;

        DateTime entityTypeCreatedDatetime = UtcDateTimeConverterFrom<EntityTypeInternal>.From(rule.Audit.Brief.CreatedAt).Value;

        EntityTypeAttributeInternal[] attributes = rule.EntityType.Attributes.Select(EntityTypeAttributeInternalFromDomainConverter.FromDomain).ToArray();

        var result = new GetSupportRequestRulesQueryResponseApprovalRuleInternal(
            entityTypeId,
            rule.EntityType.DisplayName,
            rule.Audit.Brief.CreatedBy.Value,
            rule.Audit.Brief.UpdatedBy.Value,
            entityTypeUpdatedDate,
            entityTypeCreatedDatetime,
            attributes,
            rule.IsActive,
            rule.ConcurrencyToken);

        return result;
    }
}
