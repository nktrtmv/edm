using System.Text.Json.Serialization;

using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Processes;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Types;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Swagger.Attributes;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps;

[DiscriminatorType<DocumentWorkflowStepTypeInternal>]
[JsonDerivedType(typeof(DocumentWorkflowStepInternal), nameof(DocumentWorkflowStepTypeInternal.Simple))]
[JsonDerivedType(typeof(DocumentWorkflowApprovalStepInternal), nameof(DocumentWorkflowStepTypeInternal.Approval))]
[JsonDerivedType(typeof(DocumentWorkflowSigningStepInternal), nameof(DocumentWorkflowStepTypeInternal.Signing))]
public class DocumentWorkflowStepInternal
{
    public required DateTime Date { get; init; }
    public required DocumentStatusInternal Status { get; init; }
    public DocumentStepProcessedInternal? Processed { get; set; }
    public required int Number { get; init; }

    public string[]? Responsible { get; init; }
}
