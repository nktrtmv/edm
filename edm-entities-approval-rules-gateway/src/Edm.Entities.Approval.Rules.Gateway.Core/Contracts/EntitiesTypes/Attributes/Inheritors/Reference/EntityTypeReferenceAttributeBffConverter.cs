using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;

internal static class EntityTypeReferenceAttributeBffConverter
{
    internal static EntityTypeReferenceAttributeBff FromDto(EntityTypeAttributeDataBff data, EntityTypeReferenceAttributeDto source)
    {
        var result = new EntityTypeReferenceAttributeBff
        {
            Data = data,
            ReferenceTypeId = source.ReferenceTypeId
        };

        return result;
    }

    internal static EntityTypeAttributeDto ToDto(EntityTypeReferenceAttributeBff attribute)
    {
        var asReference = new EntityTypeReferenceAttributeDto
        {
            ReferenceTypeId = attribute.ReferenceTypeId
        };

        var result = new EntityTypeAttributeDto
        {
            AsReference = asReference
        };

        return result;
    }

    internal static EntityTypeReferenceAttributeBff FromDto(int id, ApprovalEnrichersContext context)
    {
        var result = new EntityTypeReferenceAttributeBff
        {
            Data = new EntityTypeAttributeDataBff
            {
                Id = id
            }
        };

        var targetEnricher = new EntityTypeReferenceAttributeBffEnricherTarget(result);

        context.Add(targetEnricher);

        return result;
    }
}
