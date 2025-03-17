using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions.Inheritors;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Update.Actions;

internal static class UpdateApprovalRulesCommandActionInternalConverter
{
    internal static UpdateApprovalRulesCommandActionInternal FromDto(UpdateApprovalRulesCommandAction action)
    {
        UpdateApprovalRulesCommandReplacePersonActionInternal result = action.ActionCase switch
        {
            UpdateApprovalRulesCommandAction.ActionOneofCase.ReplacePerson => ToReplacePerson(action.ReplacePerson),
            _ => throw new ArgumentTypeOutOfRangeException(action.ActionCase)
        };

        return result;
    }

    private static UpdateApprovalRulesCommandReplacePersonActionInternal ToReplacePerson(UpdateApprovalRulesCommandReplacePersonAction action)
    {
        Id<UserInternal> personFromId = IdConverterFrom<UserInternal>.FromString(action.PersonFromId);

        Id<UserInternal> personToId = IdConverterFrom<UserInternal>.FromString(action.PersonToId);

        var result = new UpdateApprovalRulesCommandReplacePersonActionInternal(personFromId, personToId);

        return result;
    }
}
