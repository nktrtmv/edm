using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create;

public sealed class CreateApprovalGraphsCommandService : ApprovalGraphsServiceBase
{
    public CreateApprovalGraphsCommandService(ApprovalGraphsService.ApprovalGraphsServiceClient graphs) : base(graphs)
    {
    }

    public async Task<CreateApprovalGraphsCommandResponseBff> Create(
        CreateApprovalGraphsCommandBff command,
        string currentUserId,
        CancellationToken cancellationToken)
    {
        var request = CreateApprovalGraphsCommandBffConverter.ToDto(command, currentUserId);

        var response = await Graphs.CreateAsync(request, cancellationToken: cancellationToken);

        var result = CreateApprovalGraphsCommandResponseBffConverter.FromDto(response, command.ApprovalRuleKey);

        return result;
    }
}
