using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.EntitiesTypes.Keys;

internal static class EntityTypeKeyDbConverter
{
    internal static EntityTypeKeyDb FromDomain(EntityTypeKey entityTypeKey)
    {
        string domainId = entityTypeKey.DomainId.Value;
        var entityTypeId = IdConverterTo.ToString(entityTypeKey.EntityTypeId);
        var entityTypeUpdatedDate = UtcDateTimeConverterTo.ToDateTime(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyDb(domainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }

    internal static EntityTypeKey ToDomain(string domainIdDb, string entityTypeIdDb, DateTime entityTypeUpdatedDateDb)
    {
        DomainId domainId = DomainId.Parse(domainIdDb);
        Id<EntityType> entityTypeId = IdConverterFrom<EntityType>.FromString(entityTypeIdDb);
        UtcDateTime<EntityType> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityType>.FromUnspecifiedUtcDateTime(entityTypeUpdatedDateDb);

        var result = new EntityTypeKey(domainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }
}
