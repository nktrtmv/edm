using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions.Inheritors;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions;

internal static class UpdateApprovalRulesCommandActionBffConverter
{
    internal static UpdateApprovalRulesCommandAction ToDto(UpdateApprovalRulesCommandActionBff action)
    {
        var result = action switch
        {
            UpdateApprovalRulesCommandReplacePersonActionBff replacePerson
                => UpdateApprovalRulesCommandReplacePersonActionBffConverter.ToDto(replacePerson),

            _ => throw new ArgumentTypeOutOfRangeException(action)
        };

        return result;
    }
}
