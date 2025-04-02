using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.ApprovalRuleKeys.EntityTypeKeys;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.ApprovalRuleKeys;

internal static class ApprovalRuleKeyConverter
{
    internal static ApprovalRuleKeyDto FromInternal(ApprovalRuleKeyInternal ruleKey)
    {
        var result = new ApprovalRuleKeyDto
        {
            EntityTypeKey = EntityTypeKeyConverter.FromInternal(ruleKey.EntityTypeKey),
            Version = ruleKey.Version ?? 0
        };

        return result;
    }
}

