using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Validators;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate.Factories;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Factories;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters;

public static class ApprovalRuleUpdater
{
    public static void Update(ApprovalRule rule, Id<User> currentUserId, Action update)
    {
        if (rule.HasBeenActivated)
        {
            throw new ApplicationException(
                $"""
                 Approval rule has already been activated, so it cannot be updated.
                 EntityTypeKey: {rule.EntityType.Key}
                 RuleVersion: {rule.Version}
                 """);
        }

        ApprovalRuleNotDeletedStateValidator.Validate(rule);

        Audit<ApprovalRule> audit = AuditFactory<ApprovalRule>.CreateFrom(rule.Audit, currentUserId);
        rule.SetAudit(audit);

        update();
    }

    public static void Activate(ApprovalRule rule, Id<User> currentUserId, string comment)
    {
        ApprovalRuleNotDeletedStateValidator.Validate(rule);

        ApprovalRuleHasAnyActiveGraphValidator.Validate(rule);

        rule.SetIsActive(true);

        ApprovalRuleActivatedAuditRecord record = ApprovalRuleActivatedAuditRecordFactory.CreateNew(currentUserId, comment);

        Audit<ApprovalRule> audit = AuditFactory<ApprovalRule>.CreateFrom(rule.Audit, record);

        rule.SetAudit(audit);
    }

    public static void Deactivate(ApprovalRule rule, Id<User> currentUserId, string comment)
    {
        ApprovalRuleNotDeletedStateValidator.Validate(rule);

        rule.SetIsActive(false);

        ApprovalRuleDeactivatedAuditRecord record = ApprovalRuleDeactivatedAuditRecordFactory.CreateNew(currentUserId, comment);

        Audit<ApprovalRule> audit = AuditFactory<ApprovalRule>.CreateFrom(rule.Audit, record);

        rule.SetAudit(audit);
    }
}
