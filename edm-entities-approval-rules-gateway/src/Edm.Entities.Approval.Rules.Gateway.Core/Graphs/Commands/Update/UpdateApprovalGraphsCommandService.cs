using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update;

public sealed class UpdateApprovalGraphsCommandService : ApprovalGraphsServiceBase
{
    public UpdateApprovalGraphsCommandService(ApprovalGraphsService.ApprovalGraphsServiceClient graphs) : base(graphs)
    {
    }

    public async Task<UpdateApprovalGraphsCommandResponseBff> Update(UpdateApprovalGraphsCommandBff command, string currentUserId, CancellationToken cancellationToken)
    {
        var request = UpdateApprovalGraphsCommandBffConverter.ToDto(command, currentUserId);

        await Graphs.UpdateAsync(request, cancellationToken: cancellationToken);

        var result = UpdateApprovalGraphsCommandResponseBffConverter.FromDto(command.ApprovalRuleKey);

        return result;
    }
}
