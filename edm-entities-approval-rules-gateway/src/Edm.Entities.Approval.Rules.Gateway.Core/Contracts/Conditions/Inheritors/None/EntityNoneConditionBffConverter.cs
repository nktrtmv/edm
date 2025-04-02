using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.None;

internal static class EntityNoneConditionBffConverter
{
    internal static EntityNoneConditionBff FromDto()
    {
        return new EntityNoneConditionBff();
    }

    internal static EntityNoneConditionDto ToDto()
    {
        var result = new EntityNoneConditionDto();

        return result;
    }
}
