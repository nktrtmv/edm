namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment;

public sealed record ReferenceValueEnricherKey(
    string ReferenceTypeId,
    string Id,
    string TemplateId);
