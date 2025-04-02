using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts;

internal static class UpdateApprovalRulesCommandBffConverter
{
    internal static UpdateApprovalRulesCommand ToDto(UpdateApprovalRulesCommandBff command, string currentUserId)
    {
        ApprovalRuleKeyDto[] keys = command.Keys.Select(ApprovalRuleKeyBffConverter.ToDto).ToArray();

        var action = UpdateApprovalRulesCommandActionBffConverter.ToDto(command.Action);

        var result = new UpdateApprovalRulesCommand
        {
            Keys = { keys },
            Action = action,
            IsDryRun = command.IsDryRun,
            IsActivationRequired = command.IsActivationRequired,
            Comment = command.Comment,
            CurrentUserId = currentUserId
        };

        return result;
    }
}
