using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Entities.Types;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Commands.UpsertEntityType;

internal static class UpsertEntityTypeApprovalRulesCommandInternalConverter
{
    internal static UpsertEntityTypeApprovalRulesCommandInternal FromDto(UpsertEntityTypeApprovalRulesCommand command)
    {
        EntityTypeInternal entityType = EntityTypeInternalConverter.FromDto(command.EntityType);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        var result = new UpsertEntityTypeApprovalRulesCommandInternal(entityType, currentUserId);

        return result;
    }
}
