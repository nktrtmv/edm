namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Activate.Contracts;

public sealed class ActivateApprovalRulesCommandResponseBff
{
    private ActivateApprovalRulesCommandResponseBff()
    {
    }

    public static ActivateApprovalRulesCommandResponseBff Instance { get; } = new ActivateApprovalRulesCommandResponseBff();
}
