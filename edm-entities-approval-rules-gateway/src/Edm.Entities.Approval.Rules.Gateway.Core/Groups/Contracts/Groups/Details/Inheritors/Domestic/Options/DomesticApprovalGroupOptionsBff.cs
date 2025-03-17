namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;

public sealed class DomesticApprovalGroupOptionsBff
{
    public required bool MultipleParticipantsAreAllowed { get; init; }
    public required bool EmptyGroupIsAllowed { get; init; }
}
