using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create.Contracts;

internal static class CreateApprovalGraphsCommandResponseBffConverter
{
    internal static CreateApprovalGraphsCommandResponseBff FromDto(
        CreateApprovalGraphsCommandResponse command,
        ApprovalRuleKeyBff approvalRuleKey)
    {
        var result = new CreateApprovalGraphsCommandResponseBff
        {
            ApprovalRuleKey = approvalRuleKey,
            GraphId = command.GraphId
        };

        return result;
    }
}
