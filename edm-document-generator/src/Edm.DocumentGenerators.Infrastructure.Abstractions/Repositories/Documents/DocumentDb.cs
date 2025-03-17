namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;

public sealed class DocumentDb
{
    public required string Id { get; init; }
    public string? DomainId { get; init; }
    public required string TemplateId { get; init; }
    public required string? TemplateSystemName { get; init; }
    public required string StatusId { get; init; }
    public required byte[] Data { get; init; }
    public required string CreatedById { get; init; }
    public required string UpdatedById { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; init; }
    public required DateTime ConcurrencyToken { get; init; }
}
