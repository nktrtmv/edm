using System.ComponentModel.DataAnnotations;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Classifications;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts.AttributesErrors;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed;

public sealed class DocumentDetailedBff
{
    public required string DomainId { get; init; }
    public required string Id { get; init; }
    public required string TemplateId { get; init; }
    public required DocumentClassificationBff? Classification { get; init; }
    public required DocumentStatusBff Status { get; init; }

    public required DocumentAttributeValueDetailedBff[] AttributesValues { get; init; }

    [Required]
    public required DocumentAttributeErrorBff[] AttributesErrors { get; init; } // TODO: OBSOLETE, REMOVE WHEN FRONT WILL BE READY

    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string FrontMetadata { get; init; }
    public required DocumentAuditBff Audit { get; init; }
    public required DocumentWorkflowAvailableActionsBff AvailableActions { get; init; }
    public required DocumentWorkflowStepperDetailsBff StepperDetails { get; init; }
    public required string ConcurrencyToken { get; init; }
    public required DocumentParametersBff Parameters { get; init; }
}
