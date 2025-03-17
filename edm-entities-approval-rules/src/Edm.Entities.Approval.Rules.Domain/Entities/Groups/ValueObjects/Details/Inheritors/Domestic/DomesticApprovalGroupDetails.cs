using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;

public sealed class DomesticApprovalGroupDetails : ApprovalGroupDetails
{
    internal DomesticApprovalGroupDetails(DomesticApprovalGroupOptions options, DomesticApprovalGroupParticipant[] participants)
    {
        Options = options;
        Participants = participants;
    }

    public DomesticApprovalGroupOptions Options { get; }
    public DomesticApprovalGroupParticipant[] Participants { get; }

    public override string ToString()
    {
        string participants = string.Join<DomesticApprovalGroupParticipant>(", ", Participants);

        return $"{{ {BaseToString()}, Options: {Options}, Participants: [{participants}] }}";
    }
}
