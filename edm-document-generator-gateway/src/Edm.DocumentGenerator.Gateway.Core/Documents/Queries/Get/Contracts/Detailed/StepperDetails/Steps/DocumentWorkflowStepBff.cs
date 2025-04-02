using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Processes;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;

[DiscriminatorType<DocumentWorkflowStepTypeBff>]
[JsonDerivedType(typeof(DocumentWorkflowStepBff), nameof(DocumentWorkflowStepTypeBff.Simple))]
[JsonDerivedType(typeof(DocumentWorkflowApprovalStepBff), nameof(DocumentWorkflowStepTypeBff.Approval))]
[JsonDerivedType(typeof(DocumentWorkflowSigningStepBff), nameof(DocumentWorkflowStepTypeBff.Signing))]
public class DocumentWorkflowStepBff
{
    public required DateTime Date { get; init; }
    public required DocumentStatusBff Status { get; init; }
    public DocumentStepProcessedBff? Processed { get; set; }
    public required int Number { get; init; }
}
