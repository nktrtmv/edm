using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys.ParentValues;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys.ParentsValues;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys;

internal static class ApprovalReferenceKeyBffConverter
{
    internal static ApprovalReferenceKeyExternal ToExternal(ApprovalReferenceKeyBff key)
    {
        var entityTypeKey = EntityTypeKeyBffToExternalConverter.ToExternal(key.EntityTypeKey);

        ApprovalReferenceParentValuesExternal[] parentsValues =
            key.ParentValues.Select(ApprovalReferenceParentValuesBffConverter.ToExternal).ToArray();

        var result = new ApprovalReferenceKeyExternal(entityTypeKey, key.ReferenceTypeId, parentsValues);

        return result;
    }
}
