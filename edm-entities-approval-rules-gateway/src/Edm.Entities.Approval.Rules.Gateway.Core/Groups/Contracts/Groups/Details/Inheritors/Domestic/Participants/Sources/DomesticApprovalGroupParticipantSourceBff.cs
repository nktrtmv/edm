using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Types;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;

[JsonDerivedType(typeof(AttributeDomesticApprovalGroupParticipantSourceBff), nameof(DomesticApprovalGroupParticipantSourceTypeBff.Attribute))]
[JsonDerivedType(typeof(UserDomesticApprovalGroupParticipantSourceBff), nameof(DomesticApprovalGroupParticipantSourceTypeBff.User))]
public abstract record DomesticApprovalGroupParticipantSourceBff;
