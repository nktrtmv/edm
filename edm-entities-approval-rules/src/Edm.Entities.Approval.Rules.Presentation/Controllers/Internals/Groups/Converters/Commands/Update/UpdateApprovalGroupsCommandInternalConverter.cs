using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Update;

internal static class UpdateApprovalGroupsCommandInternalConverter
{
    internal static UpdateApprovalGroupsCommandInternal FromDto(UpdateApprovalGroupsCommand command)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(command.ApprovalRuleKey);

        ApprovalGroupInternal group = ApprovalGroupInternalConverter.FromDto(command.Group);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken = ConcurrencyTokenConverterFrom<ApprovalRuleInternal>.FromString(command.ConcurrencyToken);

        var result = new UpdateApprovalGroupsCommandInternal(approvalRuleKey, group, currentUserId, concurrencyToken);

        return result;
    }
}
