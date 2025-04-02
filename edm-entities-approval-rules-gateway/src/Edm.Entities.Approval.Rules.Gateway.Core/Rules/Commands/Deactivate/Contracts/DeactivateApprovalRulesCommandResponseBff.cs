namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate.Contracts;

public sealed class DeactivateApprovalRulesCommandResponseBff
{
    private DeactivateApprovalRulesCommandResponseBff()
    {
    }

    public static DeactivateApprovalRulesCommandResponseBff Instance { get; } = new DeactivateApprovalRulesCommandResponseBff();
}
