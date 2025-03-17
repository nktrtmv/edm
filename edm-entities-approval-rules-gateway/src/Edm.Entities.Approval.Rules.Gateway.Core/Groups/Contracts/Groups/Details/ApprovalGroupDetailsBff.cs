using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Types;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details;

[JsonDerivedType(typeof(DomesticApprovalGroupDetailsBff), nameof(DomesticApprovalGroupDetailsTypeBff.Domestic))]
public abstract class ApprovalGroupDetailsBff
{
}
