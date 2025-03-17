using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data.Factories;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.Types.Attributes.Abstractions.Data;

internal static class EntityTypeAttributeDataDbConverter
{
    internal static EntityTypeAttributeDataDb FromDomain(EntityTypeAttributeData data)
    {
        var result = new EntityTypeAttributeDataDb
        {
            Id = data.Id,
            DisplayName = data.DisplayName
        };

        return result;
    }

    internal static EntityTypeAttributeData ToDomain(EntityTypeAttributeDataDb data)
    {
        EntityTypeAttributeData result = EntityTypeAttributeDataFactory.CreateFrom(data.Id, data.DisplayName);

        return result;
    }
}
