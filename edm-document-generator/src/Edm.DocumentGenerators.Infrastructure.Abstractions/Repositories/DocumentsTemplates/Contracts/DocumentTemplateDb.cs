#pragma warning disable CS8618

namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts;

public sealed class DocumentTemplateDb
{
    public required string Id { get; init; }
    public required string DomainId { get; init; }
    public required string? SystemName { get; init; }
    public required string Name { get; init; }
    public required byte[] Data { get; init; }
    public required string CreatedById { get; init; }
    public required string UpdatedById { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; init; }
    public required bool IsDeleted { get; init; }
    public required DateTime ConcurrencyToken { get; init; }
}
