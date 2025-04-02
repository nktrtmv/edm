using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

internal static class ApprovalRuleKeyInternalConverter
{
    internal static ApprovalRuleKeyDto ToDto(ApprovalRuleKeyInternal key)
    {
        EntityTypeKeyDto entityTypeKey = EntityTypeKeyDtoConverter.FromInternal(key.EntityTypeKey);

        var result = new ApprovalRuleKeyDto
        {
            EntityTypeKey = entityTypeKey,
            Version = key.Version
        };

        return result;
    }

    internal static ApprovalRuleKeyInternal FromDto(ApprovalRuleKeyDto key)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyDtoConverter.ToInternal(key.EntityTypeKey);

        var result = new ApprovalRuleKeyInternal(entityTypeKey, key.Version);

        return result;
    }
}
