using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Inheritors.Activated;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Inheritors.Deactivated;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;

internal static class ApprovalRuleAuditRecordBffConverter
{
    internal static GetActivationAuditApprovalRulesQueryResponseAuditRecordBff FromDto(
        GetActivationAuditApprovalRulesQueryResponseAuditRecord record,
        EnrichersContext context)
    {
        var updatedBy = PersonBffConverter.FromDto(record.UpdatedBy, context);

        var updatedAt = record.UpdatedAt.ToDateTime();

        GetActivationAuditApprovalRulesQueryResponseAuditRecordBff result = record.RecordCase switch
        {
            GetActivationAuditApprovalRulesQueryResponseAuditRecord.RecordOneofCase.Activated =>
                ToActivated(record.ApprovalRuleVersion, updatedBy, updatedAt, record.Activated),

            GetActivationAuditApprovalRulesQueryResponseAuditRecord.RecordOneofCase.Deactivated =>
                ToDeactivated(record.ApprovalRuleVersion, updatedBy, updatedAt, record.Deactivated),

            _ => throw new ArgumentTypeOutOfRangeException(record)
        };

        return result;
    }

    private static GetActivationAuditApprovalRulesQueryResponseActivatedAuditRecordBff ToActivated(
        int approvalRuleVersion,
        PersonBff updatedBy,
        DateTime updatedAt,
        GetActivationAuditApprovalRulesQueryResponseActivatedAuditRecord activatedRecord)
    {
        var result = new GetActivationAuditApprovalRulesQueryResponseActivatedAuditRecordBff
        {
            ApprovalRuleVersion = approvalRuleVersion,
            UpdatedBy = updatedBy,
            UpdatedAt = updatedAt,
            Comment = activatedRecord.Comment
        };

        return result;
    }

    private static GetActivationAuditApprovalRulesQueryResponseDeactivatedAuditRecordBff ToDeactivated(
        int approvalRuleVersion,
        PersonBff updatedBy,
        DateTime updatedAt,
        GetActivationAuditApprovalRulesQueryResponseDeactivatedAuditRecord deactivatedRecord)
    {
        var result = new GetActivationAuditApprovalRulesQueryResponseDeactivatedAuditRecordBff
        {
            ApprovalRuleVersion = approvalRuleVersion,
            UpdatedBy = updatedBy,
            UpdatedAt = updatedAt,
            Comment = deactivatedRecord.Comment
        };

        return result;
    }
}
