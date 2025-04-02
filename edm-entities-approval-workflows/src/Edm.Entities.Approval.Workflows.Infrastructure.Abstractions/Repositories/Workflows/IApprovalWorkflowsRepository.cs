using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Repositories.Workflows;

public interface IApprovalWorkflowsRepository
{
    Task<Id<ApprovalWorkflow>[]> GetIds(Id<ApprovalWorkflowEntity> id, CancellationToken cancellationToken);
    Task<ApprovalWorkflow?> Get(Id<ApprovalWorkflow> id, CancellationToken cancellationToken);
    Task<ApprovalWorkflow[]> GetBatch(Id<ApprovalWorkflow>[] ids, CancellationToken cancellationToken);
    Task<ApprovalWorkflow> GetRequired(Id<ApprovalWorkflow> id, CancellationToken cancellationToken);
    Task Delete(DomainId domainId, HashSet<EntityId> ids, CancellationToken cancellationToken);
    Task Upsert(ApprovalWorkflow workflow, CancellationToken cancellationToken);
    Task<Id<ApprovalWorkflow>[]> GetAllActiveIds(UtcDateTime<ApprovalWorkflowState> actualizeDate, CancellationToken cancellationToken);
}
