using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate;

public sealed class DeactivateApprovalRulesCommandService : ApprovalRulesServiceBase
{
    public DeactivateApprovalRulesCommandService(ApprovalRulesService.ApprovalRulesServiceClient rules) : base(rules)
    {
    }

    public async Task Deactivate(DeactivateApprovalRulesCommandBff command, string currentUserId, CancellationToken cancellationToken)
    {
        var request = DeactivateApprovalRulesCommandBffConverter.ToDto(command, currentUserId);

        await Rules.DeactivateAsync(request, cancellationToken: cancellationToken);
    }
}
