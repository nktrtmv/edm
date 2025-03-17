using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;

internal static class EntityConditionInternalConverter
{
    internal static EntityConditionInternal FromDomain(EntityCondition condition)
    {
        EntityConditionInternal result = condition switch
        {
            EntityAttributeValueCondition c => EntityAttributeValueConditionInternalConverter.FromDomain(c),
            EntityLogicalNaryCondition c => EntityLogicalNaryConditionInternalConverter.FromDomain(c),
            EntityLogicalUnaryCondition c => EntityLogicalUnaryConditionInternalConverter.FromDomain(c),
            EntityNoneCondition => EntityNoneConditionInternal.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    internal static EntityCondition ToDomain(EntityConditionInternal condition)
    {
        EntityCondition result = condition switch
        {
            EntityAttributeValueConditionInternal c => EntityAttributeValueConditionInternalConverter.ToDomain(c),
            EntityLogicalNaryConditionInternal c => EntityLogicalNaryConditionInternalConverter.ToDomain(c),
            EntityLogicalUnaryConditionInternal c => EntityLogicalUnaryConditionInternalConverter.ToDomain(c),
            EntityNoneConditionInternal => EntityNoneCondition.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }
}
