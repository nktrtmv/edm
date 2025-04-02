using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data.Factories;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;

internal static class EntityTypeAttributeDataInternalConverter
{
    internal static EntityTypeAttributeDataInternal FromDomain(EntityTypeAttributeData data)
    {
        var result = new EntityTypeAttributeDataInternal(data.Id, data.DisplayName);

        return result;
    }

    internal static EntityTypeAttributeData ToDomain(EntityTypeAttributeDataInternal data)
    {
        EntityTypeAttributeData result = EntityTypeAttributeDataFactory.CreateFrom(data.Id, data.DisplayName);

        return result;
    }
}
