using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys.EntitiesTypesKeys;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys;

internal static class ApprovalRuleKeyInternalConverter
{
    internal static ApprovalRuleKeyInternal FromExternal(ApprovalRuleKeyExternal approvalRuleKey)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyInternalConverter.FromExternal(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyInternal(entityTypeKey, approvalRuleKey.Version);

        return result;
    }
}
