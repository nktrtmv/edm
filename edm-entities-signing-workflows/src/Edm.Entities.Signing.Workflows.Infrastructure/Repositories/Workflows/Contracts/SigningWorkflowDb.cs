namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts;

internal sealed class SigningWorkflowDb
{
    internal required string Id { get; init; }
    internal required string EntityId { get; init; }
    internal required string DomainId { get; init; }
    internal required string Status { get; init; }
    internal required DateTime StatusChangedAt { get; init; }
    internal required byte[] Data { get; init; }
    internal required DateTime ConcurrencyToken { get; init; }
}
