using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Naries;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Unaries;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions;

internal static class EntityConditionDbConverter
{
    internal static EntityCondition ToDomain(EntityConditionDb condition)
    {
        EntityCondition result = condition.ValueCase switch
        {
            EntityConditionDb.ValueOneofCase.AsAttributeValue =>
                EntityAttributeValueConditionDbConverter.ToDomain(condition.AsAttributeValue),

            EntityConditionDb.ValueOneofCase.AsLogicalNary =>
                EntityLogicalNaryConditionDbConverter.ToDomain(condition.AsLogicalNary),

            EntityConditionDb.ValueOneofCase.AsLogicalUnary =>
                EntityLogicalUnaryConditionDbConverter.ToDomain(condition.AsLogicalUnary),

            EntityConditionDb.ValueOneofCase.AsNone => EntityNoneCondition.Instance,

            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    internal static EntityConditionDb FromDomain(EntityCondition condition)
    {
        EntityConditionDb result = condition switch
        {
            EntityAttributeValueCondition c =>
                new EntityConditionDb { AsAttributeValue = EntityAttributeValueConditionDbConverter.FromDomain(c) },

            EntityLogicalNaryCondition c =>
                new EntityConditionDb { AsLogicalNary = EntityLogicalNaryConditionDbConverter.FromDomain(c) },

            EntityLogicalUnaryCondition c =>
                new EntityConditionDb { AsLogicalUnary = EntityLogicalUnaryConditionDbConverter.FromDomain(c) },

            EntityNoneCondition =>
                new EntityConditionDb { AsNone = new EntityNoneConditionDb() },

            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }
}
