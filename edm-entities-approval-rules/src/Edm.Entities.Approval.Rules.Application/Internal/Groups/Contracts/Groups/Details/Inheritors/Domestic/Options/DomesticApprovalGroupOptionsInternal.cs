namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;

public sealed class DomesticApprovalGroupOptionsInternal
{
    public DomesticApprovalGroupOptionsInternal(bool multipleParticipantsAreAllowed, bool emptyGroupIsAllowed)
    {
        MultipleParticipantsAreAllowed = multipleParticipantsAreAllowed;
        EmptyGroupIsAllowed = emptyGroupIsAllowed;
    }

    public bool MultipleParticipantsAreAllowed { get; }
    public bool EmptyGroupIsAllowed { get; }
}
