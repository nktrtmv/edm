using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Keys;

internal static class ApprovalRuleKeyDbConverter
{
    internal static ApprovalRuleKeyDb FromDomain(ApprovalRuleKey key)
    {
        string domainId = key.EntityTypeKey.DomainId.Value;

        var entityTypeId = IdConverterTo.ToString(key.EntityTypeKey.EntityTypeId);

        var entityTypeUpdatedDate = UtcDateTimeConverterTo.ToDateTime(key.EntityTypeKey.EntityTypeUpdatedDate);

        var result = new ApprovalRuleKeyDb
        {
            DomainId = domainId,
            EntityTypeId = entityTypeId,
            EntityTypeUpdatedDate = entityTypeUpdatedDate,
            Version = key.Version
        };

        return result;
    }

    internal static ApprovalRuleKey ToDomain(ApprovalRuleKeyDb key)
    {
        EntityTypeKey entityTypeKey = EntityTypeKeyDbConverter.ToDomain(key.DomainId, key.EntityTypeId, key.EntityTypeUpdatedDate);

        var result = new ApprovalRuleKey(entityTypeKey, key.Version);

        return result;
    }
}
