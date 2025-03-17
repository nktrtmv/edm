using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Records.Activate;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Records.Deactivate;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetActivationAudit.Audits;

internal static class ApprovalRuleActivationAuditRecordInternalConverter
{
    internal static GetActivationAuditApprovalRulesQueryResponseAuditRecord ToDto(ApprovalRuleActivationAuditRecordInternal record)
    {
        var updatedBy = IdConverterTo.ToString(record.Record.Heading.UpdatedBy);
        Timestamp updatedAt = UtcDateTimeConverterTo.ToTimeStamp(record.Record.Heading.UpdatedAt);

        var result = new GetActivationAuditApprovalRulesQueryResponseAuditRecord
        {
            ApprovalRuleVersion = record.ApprovalRuleVersion,
            UpdatedBy = updatedBy,
            UpdatedAt = updatedAt
        };

        _ = record.Record switch
        {
            ApprovalRuleActivatedAuditRecordInternal activated => ToActivated(result, activated.Comment),
            ApprovalRuleDeactivatedAuditRecordInternal deactivated => ToDeactivated(result, deactivated.Comment),
            _ => throw new ArgumentTypeOutOfRangeException(record.Record)
        };

        return result;
    }

    private static None ToActivated(GetActivationAuditApprovalRulesQueryResponseAuditRecord record, string comment)
    {
        record.Activated = new GetActivationAuditApprovalRulesQueryResponseActivatedAuditRecord
        {
            Comment = comment
        };

        return default;
    }

    private static None ToDeactivated(GetActivationAuditApprovalRulesQueryResponseAuditRecord record, string comment)
    {
        record.Deactivated = new GetActivationAuditApprovalRulesQueryResponseDeactivatedAuditRecord
        {
            Comment = comment
        };

        return default;
    }
}
