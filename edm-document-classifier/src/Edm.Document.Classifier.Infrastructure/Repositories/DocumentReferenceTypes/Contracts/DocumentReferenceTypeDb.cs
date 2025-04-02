namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts;

internal sealed record DocumentReferenceTypeDb
{
    public required string Id { get; init; }
    public required int ReferenceTypeId { get; init; }
    public string? DomainId { get; init; }
    public required string DisplayName { get; init; }
    public required byte[] Data { get; init; }
    public required string CreatedById { get; init; }
    public required string UpdatedById { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; init; }
    public required DateTime ConcurrencyToken { get; init; }
    public required int Version { get; set; }
}
