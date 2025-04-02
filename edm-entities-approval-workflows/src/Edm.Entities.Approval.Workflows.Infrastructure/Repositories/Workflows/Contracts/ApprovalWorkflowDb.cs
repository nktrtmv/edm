namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts;

internal sealed class ApprovalWorkflowDb
{
    internal required string Id { get; init; }
    internal required string EntityId { get; init; }
    internal required string EntityDomainId { get; init; }
    internal required string Status { get; init; }
    internal required byte[] Data { get; init; }
    internal DateTime? ActualizedDate { get; init; }
    internal required DateTime CreatedDate { get; init; }
    internal required DateTime UpdatedDate { get; init; }
}
