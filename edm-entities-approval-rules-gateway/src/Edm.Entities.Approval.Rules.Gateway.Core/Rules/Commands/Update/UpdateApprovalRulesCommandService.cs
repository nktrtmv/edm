using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update;

public sealed class UpdateApprovalRulesCommandService : ApprovalRulesServiceBase
{
    public UpdateApprovalRulesCommandService(ApprovalRulesService.ApprovalRulesServiceClient rules) : base(rules)
    {
    }

    public async Task<UpdateApprovalRulesCommandResponseBff> Update(
        UpdateApprovalRulesCommandBff command,
        string currentUserId,
        CancellationToken cancellationToken)
    {
        var request = UpdateApprovalRulesCommandBffConverter.ToDto(command, currentUserId);

        var response = await Rules.UpdateAsync(request, cancellationToken: cancellationToken);

        var result = UpdateApprovalRulesCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
