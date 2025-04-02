using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Activate.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Activate;

public sealed class ActivateApprovalRulesCommandService : ApprovalRulesServiceBase
{
    public ActivateApprovalRulesCommandService(ApprovalRulesService.ApprovalRulesServiceClient rules) : base(rules)
    {
    }

    public async Task Activate(ActivateApprovalRulesCommandBff command, string currentUserId, CancellationToken cancellationToken)
    {
        var request = ActivateApprovalRulesCommandBffConverter.ToDto(command, currentUserId);

        await Rules.ActivateAsync(request, cancellationToken: cancellationToken);
    }
}
