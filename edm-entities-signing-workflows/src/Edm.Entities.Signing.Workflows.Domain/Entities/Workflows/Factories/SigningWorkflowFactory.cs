using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Factories;

public static class SigningWorkflowFactory
{
    public static SigningWorkflow CreateNew(
        Id<SigningWorkflow> id,
        Id<Entity> entityId,
        Id<EntityDomain> domainId,
        SigningParty[] parties,
        SigningParameters parameters)
    {
        SigningState state = SigningStateFactory.CreateNew(parties);

        var applicationEvents = new List<SigningApplicationEvent>();

        var concurrencyToken = ConcurrencyToken<SigningWorkflow>.Empty;

        SigningWorkflow result = CreateFromDb(id, entityId, domainId, state, parameters, applicationEvents, concurrencyToken);

        SigningWorkflowStatusUpdater.Advance(result, false);

        return result;
    }

    public static SigningWorkflow CreateFromDb(
        Id<SigningWorkflow> id,
        Id<Entity> entityId,
        Id<EntityDomain> domainId,
        SigningState state,
        SigningParameters parameters,
        List<SigningApplicationEvent> applicationEvents,
        ConcurrencyToken<SigningWorkflow> concurrencyToken)

    {
        var result = new SigningWorkflow(id, entityId, domainId, state, parameters, applicationEvents, concurrencyToken);

        return result;
    }
}
