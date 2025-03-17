using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete;

public sealed class DeleteApprovalGroupsCommandService : ApprovalGroupsServiceBase
{
    public DeleteApprovalGroupsCommandService(ApprovalGroupsService.ApprovalGroupsServiceClient groups) : base(groups)
    {
    }

    public async Task Delete(DeleteApprovalGroupsCommandBff command, string currentUserId, CancellationToken cancellationToken)
    {
        var request = DeleteApprovalGroupsCommandBffConverter.ToDto(command, currentUserId);

        await Groups.DeleteAsync(request, cancellationToken: cancellationToken);
    }
}
