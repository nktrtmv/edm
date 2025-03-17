using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.SearchValues.Contracts.Values;

internal static class ApprovalReferenceValueExternalConverter
{
    internal static ApprovalReferenceValueExternal FromDto(ApprovalReferenceValueDto value)
    {
        var result = new ApprovalReferenceValueExternal(value.Id, value.DisplayValue, value.DisplaySubValue);

        return result;
    }
}
