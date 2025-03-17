using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.DeleteEntityType.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Commands.DeleteEntityType;

internal static class DeleteEntityTypeApprovalRulesCommandInternalConverter
{
    internal static DeleteEntityTypeApprovalRulesCommandInternal FromDto(DeleteEntityTypeApprovalRulesCommand command)
    {
        EntityTypeKeyInternal newEntityTypeKey = EntityTypeKeyDtoConverter.ToInternal(command.EntityTypeKey);

        var result = new DeleteEntityTypeApprovalRulesCommandInternal(newEntityTypeKey, command.CurrentUserId);

        return result;
    }
}
