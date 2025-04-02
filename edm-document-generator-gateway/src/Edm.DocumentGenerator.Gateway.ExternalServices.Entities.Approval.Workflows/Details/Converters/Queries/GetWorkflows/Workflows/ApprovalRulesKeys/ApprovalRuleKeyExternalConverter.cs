using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.ApprovalRulesKeys.
    EntitiesTypesKeys;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.ApprovalRulesKeys;

internal static class ApprovalRuleKeyExternalConverter
{
    internal static ApprovalRuleKeyExternal FromDto(ApprovalRuleKeyDto ruleKey)
    {
        var entityTypeKey = EntityTypeKeyExternalConverter.FromDto(ruleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyExternal(entityTypeKey, ruleKey.Version);

        return result;
    }
}
