using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Inheritors.Activated;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Inheritors.Deactivated;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;

[JsonDerivedType(typeof(GetActivationAuditApprovalRulesQueryResponseActivatedAuditRecordBff), "Activated")]
[JsonDerivedType(typeof(GetActivationAuditApprovalRulesQueryResponseDeactivatedAuditRecordBff), "Deactivated")]
public abstract class GetActivationAuditApprovalRulesQueryResponseAuditRecordBff
{
    public required int ApprovalRuleVersion { get; init; }
    public required PersonBff UpdatedBy { get; init; }
    public required DateTime UpdatedAt { get; init; }
}
