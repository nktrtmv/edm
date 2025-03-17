using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules.Types;

internal static class EntityTypeSlimBffConverter
{
    internal static EntityTypeSlimBff FromDto(GetAllApprovalRulesQueryResponseEntityTypeDto source)
    {
        var result = new EntityTypeSlimBff
        {
            Key = EntityTypeKeyBffConverter.FromDto(source.Key),
            DisplayName = source.DisplayName,
            IsActive = source.IsActive
        };

        return result;
    }
}
