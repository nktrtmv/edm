using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference.Values;

internal static class EntityReferenceAttributeValueValueBffConverter
{
    internal static EntityReferenceAttributeValueValueBff FromExternal(ApprovalReferenceValueExternal value)
    {
        var result = new EntityReferenceAttributeValueValueBff
        {
            Id = value.Id,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue
        };

        return result;
    }
}
