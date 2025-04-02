using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Contracts.EntityTypesKeys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

internal static class EntityTypeKeyBffToExternalConverter
{
    internal static EntityTypeKeyExternal ToExternal(EntityTypeKeyBff key)
    {
        var result = new EntityTypeKeyExternal(key.DomainId, key.EntityTypeId, key.EntityTypeUpdatedDate);

        return result;
    }
}
