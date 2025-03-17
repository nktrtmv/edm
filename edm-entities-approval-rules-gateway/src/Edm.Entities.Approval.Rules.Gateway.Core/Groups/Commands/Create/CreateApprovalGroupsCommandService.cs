using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create;

public sealed class CreateApprovalGroupsCommandService : ApprovalGroupsServiceBase
{
    public CreateApprovalGroupsCommandService(ApprovalGroupsService.ApprovalGroupsServiceClient groups) : base(groups)
    {
    }

    public async Task<CreateApprovalGroupsCommandResponseBff> Create(
        CreateApprovalGroupsCommandBff command,
        string currentUserId,
        CancellationToken cancellationToken)
    {
        var request = CreateApprovalGroupsCommandBffConverter.ToDto(command, currentUserId);

        var response = await Groups.CreateAsync(request, cancellationToken: cancellationToken);

        var result = CreateApprovalGroupsCommandResponseBffConverter.FromDto(response, command.ApprovalRuleKey);

        return result;
    }
}
