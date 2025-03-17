using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions.Inheritors;

internal static class UpdateApprovalRulesCommandReplacePersonActionInternalConverter
{
    internal static ApprovalRulesReplacePersonAction ToDomain(UpdateApprovalRulesCommandReplacePersonActionInternal action)
    {
        Id<User> personFromId = IdConverterFrom<User>.From(action.PersonFromId);

        Id<User> personToId = IdConverterFrom<User>.From(action.PersonToId);

        var result = new ApprovalRulesReplacePersonAction(personFromId, personToId);

        return result;
    }
}
