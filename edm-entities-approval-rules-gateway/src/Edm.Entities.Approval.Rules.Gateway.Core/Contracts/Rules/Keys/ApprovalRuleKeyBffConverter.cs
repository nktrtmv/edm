using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

internal static class ApprovalRuleKeyBffConverter
{
    internal static ApprovalRuleKeyBff FromDto(ApprovalRuleKeyDto key)
    {
        var entityTypeKey = EntityTypeKeyBffConverter.FromDto(key.EntityTypeKey);

        var result = new ApprovalRuleKeyBff
        {
            EntityTypeKey = entityTypeKey,
            Version = key.Version
        };

        return result;
    }

    internal static ApprovalRuleKeyDto ToDto(ApprovalRuleKeyBff key)
    {
        var entityTypeKey = EntityTypeKeyBffConverter.ToDto(key.EntityTypeKey);

        var result = new ApprovalRuleKeyDto
        {
            EntityTypeKey = entityTypeKey,
            Version = key.Version
        };

        return result;
    }
}
