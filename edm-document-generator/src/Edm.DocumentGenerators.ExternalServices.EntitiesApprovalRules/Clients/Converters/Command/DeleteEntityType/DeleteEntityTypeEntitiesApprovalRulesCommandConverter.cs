using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Contracts.EntityTypeKeys;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.DeleteEntityType;

internal static class DeleteEntityTypeEntitiesApprovalRulesCommandConverter
{
    internal static DeleteEntityTypeApprovalRulesCommand FromExternal(EntitiesApprovalRuleEntityTypeKeyExternal entityTypeKey, Id<User> currentUserId)
    {
        EntityTypeKeyDto entityTypeKeyDto = EntitiesApprovalRuleEntityTypeKeyDtoConverter.FromExternal(entityTypeKey);

        var result = new DeleteEntityTypeApprovalRulesCommand
        {
            EntityTypeKey = entityTypeKeyDto,
            CurrentUserId = currentUserId.Value
        };

        return result;
    }
}
