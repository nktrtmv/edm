using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys.EntitiesTypesKeys;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys;

public sealed record ApprovalRuleKeyInternal(EntityTypeKeyInternal EntityTypeKey, int? Version);
