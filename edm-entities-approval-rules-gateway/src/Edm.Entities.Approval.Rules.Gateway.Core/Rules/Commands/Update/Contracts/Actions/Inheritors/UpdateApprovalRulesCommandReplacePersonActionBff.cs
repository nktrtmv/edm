namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions.Inheritors;

public sealed class UpdateApprovalRulesCommandReplacePersonActionBff : UpdateApprovalRulesCommandActionBff
{
    public required string PersonFromId { get; init; }
    public required string PersonToId { get; init; }
}
