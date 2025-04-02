using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts.Audit;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts;

public sealed class DocumentTemplateDetailedBff
{
    public required string DomainId { get; init; }
    public required string Id { get; init; }
    public string? SystemName { get; init; }
    public required DocumentClassifierSubsetBff? ClassifierSubset { get; init; }
    public required string Name { get; init; }
    public required DocumentTemplateStatusBff Status { get; init; }
    public required DocumentPrototypeBff DocumentPrototype { get; init; }
    public required ApprovalRuleKeyBff? ApprovalRuleKey { get; init; }
    public required string FrontMetadata { get; init; }
    public required DocumentTemplateAuditBff Audit { get; set; }
    public required string ConcurrencyToken { get; init; }
}
