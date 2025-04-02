namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Validators;

internal static class ApprovalRuleNotDeletedStateValidator
{
    internal static void Validate(ApprovalRule rule)
    {
        if (rule.IsDeleted)
        {
            throw new ApplicationException(
                $"""
                 Approval rule has been deleted, so it cannot be updated.
                 EntityTypeKey: {rule.EntityType.Key}
                 RuleVersion: {rule.Version}
                 """);
        }
    }
}
