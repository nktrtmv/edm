using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts;

public sealed record GetStepperQueryResponseInternal(DocumentWorkflowStepInternal[] Steps, string Id, string DomainId);


