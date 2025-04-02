using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.Factories;

public static class DomesticApprovalGroupDetailsFactory
{
    public static DomesticApprovalGroupDetails CreateNew()
    {
        DomesticApprovalGroupOptions options = DomesticApprovalGroupOptionsFactory.CreateNew();

        DomesticApprovalGroupParticipant[] participants = Array.Empty<DomesticApprovalGroupParticipant>();

        DomesticApprovalGroupDetails result = CreateFromDb(options, participants);

        return result;
    }

    public static DomesticApprovalGroupDetails CreateFrom(DomesticApprovalGroupOptions options, DomesticApprovalGroupParticipant[] participants)
    {
        DomesticApprovalGroupDetails result = CreateFromDb(options, participants);

        return result;
    }

    public static DomesticApprovalGroupDetails CreateFromDb(DomesticApprovalGroupOptions options, DomesticApprovalGroupParticipant[] participants)
    {
        var result = new DomesticApprovalGroupDetails(
            options,
            participants);

        return result;
    }
}
