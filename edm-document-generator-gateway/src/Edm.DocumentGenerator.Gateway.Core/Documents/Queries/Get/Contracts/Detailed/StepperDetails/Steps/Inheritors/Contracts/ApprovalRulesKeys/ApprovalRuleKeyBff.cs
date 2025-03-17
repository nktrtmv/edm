using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys.EntitiesTypesKeys;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;

public sealed class ApprovalRuleKeyBff
{
    public required EntityTypeKeyBff EntityTypeKey { get; init; }
    public int? Version { get; init; } = null;
}
