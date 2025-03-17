using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Unaries;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions;

internal static class EntityConditionInternalConverter
{
    internal static EntityConditionInternal FromDto(EntityConditionDto condition)
    {
        EntityConditionInternal result = condition.ValueCase switch
        {
            EntityConditionDto.ValueOneofCase.AsAttributeValue =>
                EntityAttributeValueConditionDtoConverter.FromDto(condition.AsAttributeValue),

            EntityConditionDto.ValueOneofCase.AsLogicalNary =>
                EntityLogicalNaryConditionInternalConverter.FromDto(condition.AsLogicalNary),

            EntityConditionDto.ValueOneofCase.AsLogicalUnary =>
                EntityLogicalUnaryConditionInternalConverter.FromDto(condition.AsLogicalUnary),

            EntityConditionDto.ValueOneofCase.AsNone => EntityNoneConditionInternal.Instance,

            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    internal static EntityConditionDto ToDto(EntityConditionInternal condition)
    {
        EntityConditionDto result = condition switch
        {
            EntityAttributeValueConditionInternal c =>
                new EntityConditionDto { AsAttributeValue = EntityAttributeValueConditionDtoConverter.ToDto(c) },

            EntityLogicalNaryConditionInternal c =>
                new EntityConditionDto { AsLogicalNary = EntityLogicalNaryConditionInternalConverter.ToDto(c) },

            EntityLogicalUnaryConditionInternal c =>
                new EntityConditionDto { AsLogicalUnary = EntityLogicalUnaryConditionInternalConverter.ToDto(c) },

            EntityNoneConditionInternal =>
                new EntityConditionDto { AsNone = new EntityNoneConditionDto() },

            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }
}
