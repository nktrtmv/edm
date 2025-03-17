using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Processes;

public sealed record DocumentStepProcessedInternal(string ProcessedBy, DateTime ProcessedDateTime, DocumentStatusInternal NextStatus);
