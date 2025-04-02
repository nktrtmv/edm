using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic;

public sealed class DomesticApprovalGroupDetailsBff : ApprovalGroupDetailsBff
{
    public required DomesticApprovalGroupOptionsBff Options { get; init; }
    public required DomesticApprovalGroupParticipantBff[] Participants { get; init; }
}
