using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Entities;

public sealed class EntityInternal
{
    public EntityInternal( EntityTypeKeyInternal typeKey, EntityAttributeValueInternal[] attributesValues)
    {
        TypeKey = typeKey;
        AttributesValues = attributesValues;
    }

    public EntityTypeKeyInternal TypeKey { get; }
    public EntityAttributeValueInternal[] AttributesValues { get; }
}
