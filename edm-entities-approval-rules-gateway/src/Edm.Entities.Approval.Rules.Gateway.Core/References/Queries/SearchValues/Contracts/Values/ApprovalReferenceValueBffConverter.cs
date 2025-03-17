using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Values;

internal static class ApprovalReferenceValueBffConverter
{
    internal static ApprovalReferenceValueBff FromExternal(ApprovalReferenceValueExternal value)
    {
        var result = new ApprovalReferenceValueBff
        {
            Id = value.Id,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue
        };

        return result;
    }
}
