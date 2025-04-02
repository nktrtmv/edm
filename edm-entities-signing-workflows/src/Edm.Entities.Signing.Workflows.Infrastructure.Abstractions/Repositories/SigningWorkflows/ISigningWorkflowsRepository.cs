using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Repositories.SigningWorkflows;

public interface ISigningWorkflowsRepository
{
    Task<ConcurrencyToken<SigningWorkflow>> Upsert(SigningWorkflow workflow, CancellationToken cancellationToken);
    Task<SigningWorkflow?> Get(Id<SigningWorkflow> id, CancellationToken cancellationToken);
    Task<SigningWorkflow> GetRequired(Id<SigningWorkflow> workflowId, CancellationToken cancellationToken);
}
