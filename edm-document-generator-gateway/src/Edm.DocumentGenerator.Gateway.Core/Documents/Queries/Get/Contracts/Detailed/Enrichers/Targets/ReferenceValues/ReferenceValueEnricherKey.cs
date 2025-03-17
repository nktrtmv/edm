namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Targets.ReferenceValues;

public sealed record ReferenceValueEnricherKey(
    string ReferenceTypeId,
    string Id,
    string? TemplateId = null);
