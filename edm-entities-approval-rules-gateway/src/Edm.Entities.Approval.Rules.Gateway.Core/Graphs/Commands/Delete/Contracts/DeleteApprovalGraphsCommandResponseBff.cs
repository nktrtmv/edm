namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete.Contracts;

public sealed class DeleteApprovalGraphsCommandResponseBff
{
    private DeleteApprovalGraphsCommandResponseBff()
    {
    }

    public static DeleteApprovalGraphsCommandResponseBff Instance { get; } = new DeleteApprovalGraphsCommandResponseBff();
}
