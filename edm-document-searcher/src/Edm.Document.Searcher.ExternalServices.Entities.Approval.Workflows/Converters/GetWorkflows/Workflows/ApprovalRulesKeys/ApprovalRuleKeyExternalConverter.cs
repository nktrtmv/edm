using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys.EntitiesTypesKeys;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.ApprovalRulesKeys.EntitiesTypesKeys;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.ApprovalRulesKeys;

internal static class ApprovalRuleKeyExternalConverter
{
    internal static ApprovalRuleKeyExternal FromDto(ApprovalRuleKeyDto ruleKey)
    {
        EntityTypeKeyExternal entityTypeKey = EntityTypeKeyExternalConverter.FromDto(ruleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyExternal(entityTypeKey, ruleKey.Version);

        return result;
    }
}
