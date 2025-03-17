using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

internal static class EntityConditionOperatorBffConverter
{
    internal static EntityConditionOperatorBff FromDto(EntityConditionOperatorDto source)
    {
        var kind = EntityConditionOperatorKindBffConverter.FromDto(source.Kind);

        var type = EntityConditionOperatorTypeBffConverter.FromDto(source.Type);

        var result = new EntityConditionOperatorBff
        {
            Kind = kind,
            Type = type,
            DisplayName = source.DisplayName
        };

        return result;
    }

    internal static EntityConditionOperatorDto ToDto(EntityConditionOperatorBff source)
    {
        var kind = EntityConditionOperatorKindBffConverter.ToDto(source.Kind);
        var type = EntityConditionOperatorTypeBffConverter.ToDto(source.Type);

        var result = new EntityConditionOperatorDto
        {
            Kind = kind,
            Type = type,
            DisplayName = source.DisplayName
        };

        return result;
    }
}
