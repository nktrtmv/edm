using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update.Contracts;

internal static class UpdateApprovalGraphsCommandBffConverter
{
    internal static UpdateApprovalGraphsCommand ToDto(UpdateApprovalGraphsCommandBff command, string currentUserId)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var graph = ApprovalGraphBffConverter.ToDto(command.Graph);

        var result = new UpdateApprovalGraphsCommand
        {
            ApprovalRuleKey = approvalRuleKey,
            Graph = graph,
            CurrentUserId = currentUserId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
