using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Enrichers.Sources.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference;

internal static class EntityReferenceAttributeValueBffConverter
{
    internal static EntityReferenceAttributeValueBff FromDto(
        EntityReferenceAttributeValueDto attributeValue,
        int id,
        ApprovalEnrichersContext context)
    {
        string[] ids = attributeValue.Value.ToArray();

        var referenceKey = new ApprovalReferenceKeyExternal(context.EntityTypeKey, string.Empty);

        var referenceKeyEnricher = new ApprovalReferenceKeyExternalEnricherTarget(id, referenceKey);

        context.Add(referenceKeyEnricher);

        var key = new ApprovalReferenceEnricherKey(referenceKey, ids);

        var result = new EntityReferenceAttributeValueBff
        {
            Id = id
        };

        var referenceValueEnricher = new EntityReferenceAttributeValueBffEnricherTarget(key, result);

        context.Add(referenceValueEnricher);

        return result;
    }

    internal static EntityAttributeValueDto ToDto(EntityReferenceAttributeValueBff attributeValue)
    {
        string[] value = attributeValue.Value
            .Select(v => v.Id)
            .ToArray();

        var asReference = new EntityReferenceAttributeValueDto
        {
            Value = { value }
        };

        var result = new EntityAttributeValueDto
        {
            Id = attributeValue.Id,
            AsReference = asReference
        };

        return result;
    }
}
