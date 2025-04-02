using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;

public sealed class SigningWorkflow
{
    internal SigningWorkflow(
        Id<SigningWorkflow> id,
        Id<Entity> entityId,
        Id<EntityDomain> domainId,
        SigningState state,
        SigningParameters parameters,
        List<SigningApplicationEvent> applicationEvents,
        ConcurrencyToken<SigningWorkflow> concurrencyToken)
    {
        Id = id;
        EntityId = entityId;
        DomainId = domainId;
        State = state;
        Parameters = parameters;
        ApplicationEvents = applicationEvents;
        ConcurrencyToken = concurrencyToken;
    }

    public Id<SigningWorkflow> Id { get; }
    public Id<Entity> EntityId { get; }
    public Id<EntityDomain> DomainId { get; }
    public SigningState State { get; }
    public SigningParameters Parameters { get; private set; }
    public List<SigningApplicationEvent> ApplicationEvents { get; }
    public ConcurrencyToken<SigningWorkflow> ConcurrencyToken { get; }

    public SigningStatus Status => State.Status;

    public void SetParameters(SigningParameters parameters)
    {
        Parameters = parameters;
    }

    public override string ToString()
    {
        return $"id: {Id}, status: {State.Status}, entityId: {EntityId}, domainId: {DomainId}";
    }
}
