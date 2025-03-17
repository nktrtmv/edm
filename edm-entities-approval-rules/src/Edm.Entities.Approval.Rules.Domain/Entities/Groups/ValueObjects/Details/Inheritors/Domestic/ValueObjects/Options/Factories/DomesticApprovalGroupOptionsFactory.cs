namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options.Factories;

public static class DomesticApprovalGroupOptionsFactory
{
    public static DomesticApprovalGroupOptions CreateNew()
    {
        const bool multipleParticipantsAreAllowed = false;

        const bool emptyGroupIsAllowed = false;

        DomesticApprovalGroupOptions result = CreateFromDb(multipleParticipantsAreAllowed, emptyGroupIsAllowed);

        return result;
    }

    public static DomesticApprovalGroupOptions CreateFrom(
        bool multipleParticipantsAreAllowed,
        bool emptyGroupIsAllowed)
    {
        DomesticApprovalGroupOptions result = CreateFromDb(
            multipleParticipantsAreAllowed,
            emptyGroupIsAllowed);

        return result;
    }

    public static DomesticApprovalGroupOptions CreateFromDb(
        bool multipleParticipantsAreAllowed,
        bool emptyGroupIsAllowed)
    {
        var result = new DomesticApprovalGroupOptions(
            multipleParticipantsAreAllowed,
            emptyGroupIsAllowed);

        return result;
    }
}
