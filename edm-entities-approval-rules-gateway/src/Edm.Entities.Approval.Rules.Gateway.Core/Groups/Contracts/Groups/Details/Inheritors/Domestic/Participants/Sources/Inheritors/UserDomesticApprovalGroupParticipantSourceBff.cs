using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;

public sealed record UserDomesticApprovalGroupParticipantSourceBff(PersonBff User) : DomesticApprovalGroupParticipantSourceBff;
