using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Commands.Delete;

internal static class DeleteApprovalGraphsCommandInternalConverter
{
    internal static DeleteApprovalGraphsCommandInternal FromDto(DeleteApprovalGraphsCommand command)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(command.ApprovalRuleKey);

        Id<ApprovalGraphInternal> graphId = IdConverterFrom<ApprovalGraphInternal>.FromString(command.GraphId);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken = ConcurrencyTokenConverterFrom<ApprovalRuleInternal>.FromString(command.ConcurrencyToken);

        var result = new DeleteApprovalGraphsCommandInternal(approvalRuleKey, graphId, currentUserId, concurrencyToken);

        return result;
    }
}
