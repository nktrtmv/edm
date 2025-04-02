using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions.Inheritors;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions;

internal static class UpdateApprovalRulesCommandActionInternalConverter
{
    internal static ApprovalRulesUpdateAction ToDomain(UpdateApprovalRulesCommandActionInternal action)
    {
        ApprovalRulesReplacePersonAction result = action switch
        {
            UpdateApprovalRulesCommandReplacePersonActionInternal replacePersonAction =>
                UpdateApprovalRulesCommandReplacePersonActionInternalConverter.ToDomain(replacePersonAction),

            _ => throw new ArgumentTypeOutOfRangeException(action)
        };

        return result;
    }
}
