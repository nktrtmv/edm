using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Activate.Contracts;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Activate;

internal static class ActivateApprovalRulesCommandInternalConverter
{
    internal static ActivateApprovalRulesCommandInternal FromDto(ActivateApprovalRulesCommand command)
    {
        ApprovalRuleKeyInternal key = ApprovalRuleKeyInternalConverter.FromDto(command.Key);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<ApprovalRuleInternal>.FromString(command.ConcurrencyToken);

        var result = new ActivateApprovalRulesCommandInternal(key, command.Comment, currentUserId, concurrencyToken);

        return result;
    }
}
