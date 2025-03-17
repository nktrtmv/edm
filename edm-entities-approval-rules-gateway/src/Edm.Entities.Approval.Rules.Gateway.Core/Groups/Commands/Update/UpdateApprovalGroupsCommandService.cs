using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update;

public sealed class UpdateApprovalGroupsCommandService : ApprovalGroupsServiceBase
{
    public UpdateApprovalGroupsCommandService(ApprovalGroupsService.ApprovalGroupsServiceClient groups) : base(groups)
    {
    }

    public async Task<UpdateApprovalGroupsCommandResponseBff> Update(UpdateApprovalGroupsCommandBff command, string currentUserId, CancellationToken cancellationToken)
    {
        var request = UpdateApprovalGroupsCommandBffConverter.ToDto(command, currentUserId);

        await Groups.UpdateAsync(request, cancellationToken: cancellationToken);

        var response = UpdateApprovalGroupsCommandResponseBffConverter.FromDto(command.ApprovalRuleKey);

        return response;
    }
}
