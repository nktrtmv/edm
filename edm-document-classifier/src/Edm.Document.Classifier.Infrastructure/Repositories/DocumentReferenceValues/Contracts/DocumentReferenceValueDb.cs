namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceValues.Contracts;

internal sealed record DocumentReferenceValueDb
{
    public required string Id { get; init; }
    public required string DisplayValue { get; init; }
    public string? DisplaySubValue { get; init; }
    public bool IsHidden { get; init; }
    public required int ReferenceTypeId { get; init; }
    public required string CreatedById { get; init; }
    public required string UpdatedById { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; init; }
    public required DateTime ConcurrencyToken { get; init; }
}
