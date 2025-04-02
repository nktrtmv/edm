using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.Types.Attributes.Abstractions.Data;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.Types.Attributes;

internal static class EntityTypeAttributeDbToDomainConverter
{
    internal static EntityTypeAttribute ToDomain(EntityTypeAttributeDb attribute)
    {
        EntityTypeAttributeData data = EntityTypeAttributeDataDbConverter.ToDomain(attribute.Data);

        EntityTypeAttribute result = attribute.ValueCase switch
        {
            EntityTypeAttributeDb.ValueOneofCase.AsBoolean
                => EntityAttributeFactory.CreateFrom<EntityTypeBooleanAttribute>(data),

            EntityTypeAttributeDb.ValueOneofCase.AsDate
                => EntityAttributeFactory.CreateFrom<EntityTypeDateAttribute>(data),

            // TODO: OBSOLETE START - MAKE SURE ALL MIGRATIONS ARE DONE - Int value as long.
            EntityTypeAttributeDb.ValueOneofCase.AsInt
                => EntityAttributeFactory.CreateNumberFrom(data),
            // TODO: REMOVE: END

            EntityTypeAttributeDb.ValueOneofCase.AsNumber
                => ToNumber(data, attribute.AsNumber),

            EntityTypeAttributeDb.ValueOneofCase.AsReference
                => ToReference(data, attribute.AsReference),

            EntityTypeAttributeDb.ValueOneofCase.AsString
                => EntityAttributeFactory.CreateFrom<EntityTypeStringAttribute>(data),

            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    private static EntityTypeAttribute ToNumber(
        EntityTypeAttributeData data,
        EntityTypeNumberAttributeDb attribute)
    {
        EntityTypeAttribute result = EntityAttributeFactory.CreateNumberFrom(data, attribute.Precision);

        return result;
    }

    private static EntityTypeAttribute ToReference(
        EntityTypeAttributeData data,
        EntityTypeReferenceAttributeDb attribute)
    {
        Metadata<EntityTypeReferenceAttribute> referenceTypeId =
            MetadataConverterFrom<EntityTypeReferenceAttribute>.FromString(attribute.ReferenceTypeId);

        EntityTypeAttribute result = EntityAttributeFactory.CreateReferenceFrom(data, referenceTypeId);

        return result;
    }
}
