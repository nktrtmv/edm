using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys.ParentsValues;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues.Contracts.Keys.
    ParentValues;

internal static class ApprovalReferenceParentValuesExternalConverter
{
    internal static ApprovalReferenceParentValuesDto ToDto(ApprovalReferenceParentValuesExternal values)
    {
        string[] ids = values.Ids.ToArray();

        var result = new ApprovalReferenceParentValuesDto
        {
            ReferenceTypeId = values.ReferenceTypeId,
            Ids = { ids }
        };

        return result;
    }
}
