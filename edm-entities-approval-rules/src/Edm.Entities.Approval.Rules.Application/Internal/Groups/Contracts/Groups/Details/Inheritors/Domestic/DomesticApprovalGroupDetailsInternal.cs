using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic;

public sealed class DomesticApprovalGroupDetailsInternal : ApprovalGroupDetailsInternal
{
    public DomesticApprovalGroupDetailsInternal(
        DomesticApprovalGroupOptionsInternal options,
        DomesticApprovalGroupParticipantInternal[] participants)
    {
        Options = options;
        Participants = participants;
    }

    public DomesticApprovalGroupOptionsInternal Options { get; }
    public DomesticApprovalGroupParticipantInternal[] Participants { get; }
}
