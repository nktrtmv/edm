using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType.EntityTypes.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType.EntityTypes.Attributes;

internal static class EntitiesApprovalRuleEntityTypeAttributeDtoConverter
{
    internal static EntityTypeAttributeDto FromExternal(DocumentAttribute attribute)
    {
        EntityTypeAttributeDto result = attribute switch
        {
            DocumentBooleanAttribute =>
                new EntityTypeAttributeDto { AsBoolean = new EntityTypeBooleanAttributeDto() },

            DocumentDateAttribute =>
                new EntityTypeAttributeDto { AsDate = new EntityTypeDateAttributeDto() },

            DocumentNumberAttribute a =>
                new EntityTypeAttributeDto { AsNumber = ToNumber(a) },

            DocumentReferenceAttribute a =>
                new EntityTypeAttributeDto { AsReference = ToReference(a) },

            DocumentStringAttribute =>
                new EntityTypeAttributeDto { AsString = new EntityTypeStringAttributeDto() },

            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        EntityTypeAttributeDataDto data =
            EntitiesApprovalRuleEntityTypeAttributeDataDtoConverter.FromExternal(attribute.Data);

        result.Data = data;

        return result;
    }

    private static EntityTypeNumberAttributeDto ToNumber(DocumentNumberAttribute attribute)
    {
        var result = new EntityTypeNumberAttributeDto
        {
            Precision = attribute.Precision
        };

        return result;
    }

    private static EntityTypeReferenceAttributeDto ToReference(DocumentReferenceAttribute attribute)
    {
        var referenceTypeId = MetadataConverterTo.ToString(attribute.ReferenceType);

        var result = new EntityTypeReferenceAttributeDto
        {
            ReferenceTypeId = referenceTypeId
        };

        return result;
    }
}
