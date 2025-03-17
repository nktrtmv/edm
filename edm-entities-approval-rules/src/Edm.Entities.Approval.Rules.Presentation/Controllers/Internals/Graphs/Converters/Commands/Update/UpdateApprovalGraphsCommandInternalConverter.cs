using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Commands.Update;

internal static class UpdateApprovalGraphsCommandInternalConverter
{
    internal static UpdateApprovalGraphsCommandInternal FromDto(UpdateApprovalGraphsCommand command)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(command.ApprovalRuleKey);

        ApprovalGraphInternal graph = ApprovalGraphInternalConverter.FromDto(command.Graph);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<ApprovalRuleInternal>.FromString(command.ConcurrencyToken);

        var result = new UpdateApprovalGraphsCommandInternal(approvalRuleKey, graph, currentUserId, concurrencyToken);

        return result;
    }
}
