using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys.ParentsValues;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys.ParentValues;

internal static class ApprovalReferenceParentValuesBffConverter
{
    internal static ApprovalReferenceParentValuesExternal ToExternal(ApprovalReferenceParentValuesBff parentValues)
    {
        var result = new ApprovalReferenceParentValuesExternal(parentValues.ReferenceTypeId, parentValues.Ids);

        return result;
    }
}
