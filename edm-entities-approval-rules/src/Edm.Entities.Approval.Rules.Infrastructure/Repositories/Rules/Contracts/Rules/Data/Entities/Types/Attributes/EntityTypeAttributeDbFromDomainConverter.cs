using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.Types.Attributes.Abstractions.Data;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.Types.Attributes;

internal static class EntityTypeAttributeDbFromDomainConverter
{
    internal static EntityTypeAttributeDb FromDomain(EntityTypeAttribute attribute)
    {
        EntityTypeAttributeDataDb data = EntityTypeAttributeDataDbConverter.FromDomain(attribute.Data);

        EntityTypeAttributeDb result = attribute switch
        {
            EntityTypeBooleanAttribute =>
                new EntityTypeAttributeDb { AsBoolean = new EntityTypeBooleanAttributeDb() },

            EntityTypeDateAttribute =>
                new EntityTypeAttributeDb { AsDate = new EntityTypeDateAttributeDb() },

            EntityTypeNumberAttribute a =>
                new EntityTypeAttributeDb { AsNumber = ToNumber(a) },

            EntityTypeReferenceAttribute a =>
                new EntityTypeAttributeDb { AsReference = ToReference(a) },

            EntityTypeStringAttribute =>
                new EntityTypeAttributeDb { AsString = new EntityTypeStringAttributeDb() },

            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        result.Data = data;

        return result;
    }

    private static EntityTypeNumberAttributeDb ToNumber(EntityTypeNumberAttribute attribute)
    {
        var result = new EntityTypeNumberAttributeDb
        {
            Precision = attribute.Precision
        };

        return result;
    }

    private static EntityTypeReferenceAttributeDb ToReference(EntityTypeReferenceAttribute attribute)
    {
        var referenceTypeId = MetadataConverterTo.ToString(attribute.ReferenceTypeId);

        var result = new EntityTypeReferenceAttributeDb
        {
            ReferenceTypeId = referenceTypeId
        };

        return result;
    }
}
