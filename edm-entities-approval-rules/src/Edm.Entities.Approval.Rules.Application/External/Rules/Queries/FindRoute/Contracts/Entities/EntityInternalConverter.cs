using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Converters;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Entities;

internal static class EntityInternalConverter
{
    internal static Entity ToDomain(EntityInternal entity)
    {
        EntityTypeKey typeKey = EntityTypeKeyInternalConverter.ToDomain(entity.TypeKey);

        EntityAttributeValue[] attributesValues = entity.AttributesValues.Select(EntityAttributeValueInternalToDomainConverter.ToDomain).ToArray();

        Entity result = EntityFactory.CreateFrom(typeKey, attributesValues);

        return result;
    }
}
