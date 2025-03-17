using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Delete;

internal static class DeleteApprovalGroupsCommandInternalConverter
{
    internal static DeleteApprovalGroupsCommandInternal FromDto(DeleteApprovalGroupsCommand command)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(command.ApprovalRuleKey);

        Id<ApprovalGroupInternal> groupId = IdConverterFrom<ApprovalGroupInternal>.FromString(command.GroupId);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken = ConcurrencyTokenConverterFrom<ApprovalRuleInternal>.FromString(command.ConcurrencyToken);

        var result = new DeleteApprovalGroupsCommandInternal(approvalRuleKey, groupId, currentUserId, concurrencyToken);

        return result;
    }
}
