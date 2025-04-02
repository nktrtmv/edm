using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete;

public sealed class DeleteApprovalGraphsCommandService : ApprovalGraphsServiceBase
{
    public DeleteApprovalGraphsCommandService(ApprovalGraphsService.ApprovalGraphsServiceClient graphs) : base(graphs)
    {
    }

    public async Task Delete(DeleteApprovalGraphsCommandBff command, string currentUserId, CancellationToken cancellationToken)
    {
        var request = DeleteApprovalGraphsCommandBffConverter.ToDto(command, currentUserId);

        await Graphs.DeleteAsync(request, cancellationToken: cancellationToken);
    }
}
