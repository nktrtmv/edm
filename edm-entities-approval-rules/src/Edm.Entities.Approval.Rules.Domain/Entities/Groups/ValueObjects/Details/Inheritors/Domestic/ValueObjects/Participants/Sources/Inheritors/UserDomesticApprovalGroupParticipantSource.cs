using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;

public sealed record UserDomesticApprovalGroupParticipantSource(Id<User> UserId) : DomesticApprovalGroupParticipantSource;
