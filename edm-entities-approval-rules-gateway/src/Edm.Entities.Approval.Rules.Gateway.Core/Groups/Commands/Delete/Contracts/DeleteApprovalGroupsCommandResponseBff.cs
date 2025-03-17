namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete.Contracts;

public sealed class DeleteApprovalGroupsCommandResponseBff
{
    private DeleteApprovalGroupsCommandResponseBff()
    {
    }

    public static DeleteApprovalGroupsCommandResponseBff Instance { get; } = new DeleteApprovalGroupsCommandResponseBff();
}
