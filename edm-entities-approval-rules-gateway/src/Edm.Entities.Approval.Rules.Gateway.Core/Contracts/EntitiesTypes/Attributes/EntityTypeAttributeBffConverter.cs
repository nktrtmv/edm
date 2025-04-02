using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes;

internal static class EntityTypeAttributeBffConverter
{
    internal static EntityTypeAttributeBff FromDto(EntityTypeAttributeDto attribute)
    {
        var data = EntityTypeAttributeDataBffConverter.FromDto(attribute.Data);

        EntityTypeAttributeBff result = attribute.ValueCase switch
        {
            EntityTypeAttributeDto.ValueOneofCase.AsBoolean => EntityTypeBooleanAttributeBffConverter.FromDto(data),
            EntityTypeAttributeDto.ValueOneofCase.AsDate => EntityTypeDateAttributeBffConverter.FromDto(data),
            EntityTypeAttributeDto.ValueOneofCase.AsNumber => EntityTypeNumberAttributeBffConverter.FromDto(data, attribute.AsNumber),
            EntityTypeAttributeDto.ValueOneofCase.AsReference => EntityTypeReferenceAttributeBffConverter.FromDto(data, attribute.AsReference),
            EntityTypeAttributeDto.ValueOneofCase.AsString => EntityTypeStringAttributeBffConverter.FromDto(data),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    internal static EntityTypeAttributeDto ToDto(EntityTypeAttributeBff attribute)
    {
        var result = attribute switch
        {
            EntityTypeBooleanAttributeBff => EntityTypeBooleanAttributeBffConverter.ToDto(),
            EntityTypeDateAttributeBff => EntityTypeDateAttributeBffConverter.ToDto(),
            EntityTypeNumberAttributeBff a => EntityTypeNumberAttributeBffConverter.ToDto(a),
            EntityTypeReferenceAttributeBff a => EntityTypeReferenceAttributeBffConverter.ToDto(a),
            EntityTypeStringAttributeBff => EntityTypeStringAttributeBffConverter.ToDto(),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        var data = EntityTypeAttributeDataBffConverter.ToDto(attribute.Data);

        result.Data = data;

        return result;
    }
}
