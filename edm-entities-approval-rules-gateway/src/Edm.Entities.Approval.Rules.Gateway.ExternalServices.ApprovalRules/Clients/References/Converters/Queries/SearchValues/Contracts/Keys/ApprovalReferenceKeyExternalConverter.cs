using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues.Contracts.Keys.ParentValues;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues.Contracts.Keys;

internal static class ApprovalReferenceKeyExternalConverter
{
    internal static ApprovalReferenceKeyDto ToDto(ApprovalReferenceKeyExternal key)
    {
        ApprovalReferenceParentValuesDto[] parentValues =
            key.ParentValues.Select(ApprovalReferenceParentValuesExternalConverter.ToDto).ToArray();

        var result = new ApprovalReferenceKeyDto
        {
            ReferenceTypeId = key.ReferenceTypeId,
            ParentValues = { parentValues },
            EntityTypeId = key.EntityTypeKey.EntityTypeId
        };

        return result;
    }
}
