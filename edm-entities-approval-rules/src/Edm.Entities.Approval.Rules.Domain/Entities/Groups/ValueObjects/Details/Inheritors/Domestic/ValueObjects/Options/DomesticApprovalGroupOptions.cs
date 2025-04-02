namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;

public sealed class DomesticApprovalGroupOptions
{
    internal DomesticApprovalGroupOptions(bool multipleParticipantsAreAllowed, bool emptyGroupIsAllowed)
    {
        MultipleParticipantsAreAllowed = multipleParticipantsAreAllowed;
        EmptyGroupIsAllowed = emptyGroupIsAllowed;
    }

    public bool MultipleParticipantsAreAllowed { get; }
    public bool EmptyGroupIsAllowed { get; }

    public override string ToString()
    {
        return $"{{ MultipleParticipantsAreAllowed: {MultipleParticipantsAreAllowed}, EmptyGroupIsAllowed: {EmptyGroupIsAllowed} }}";
    }
}
