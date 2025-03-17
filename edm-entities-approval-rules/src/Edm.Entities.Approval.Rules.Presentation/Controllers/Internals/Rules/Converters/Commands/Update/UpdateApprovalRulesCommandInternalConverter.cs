using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Update.Actions;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Update;

internal static class UpdateApprovalRulesCommandInternalConverter
{
    internal static UpdateApprovalRulesCommandInternal FromDto(UpdateApprovalRulesCommand command)
    {
        ApprovalRuleKeyInternal[] keys = command.Keys.Select(ApprovalRuleKeyInternalConverter.FromDto).ToArray();

        UpdateApprovalRulesCommandActionInternal actions = UpdateApprovalRulesCommandActionInternalConverter.FromDto(command.Action);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        var result = new UpdateApprovalRulesCommandInternal(keys, actions, command.IsDryRun, command.IsActivationRequired, command.Comment, currentUserId);

        return result;
    }
}
