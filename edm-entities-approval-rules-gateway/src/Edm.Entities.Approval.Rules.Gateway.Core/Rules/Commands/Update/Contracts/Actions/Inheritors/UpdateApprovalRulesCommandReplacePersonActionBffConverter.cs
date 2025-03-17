using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions.Inheritors;

internal static class UpdateApprovalRulesCommandReplacePersonActionBffConverter
{
    internal static UpdateApprovalRulesCommandAction ToDto(UpdateApprovalRulesCommandReplacePersonActionBff action)
    {
        var replacePerson = new UpdateApprovalRulesCommandReplacePersonAction
        {
            PersonFromId = action.PersonFromId,
            PersonToId = action.PersonToId
        };

        var result = new UpdateApprovalRulesCommandAction
        {
            ReplacePerson = replacePerson
        };

        return result;
    }
}
