using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Statuses;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts;

internal static class SigningWorkflowDbToDomainConverter
{
    internal static SigningWorkflow ToDomain(SigningWorkflowDb workflow)
    {
        Id<SigningWorkflow> id = IdConverterFrom<SigningWorkflow>.FromString(workflow.Id);

        Id<Entity> entityId = IdConverterFrom<Entity>.FromString(workflow.EntityId);

        Id<EntityDomain> domainId = IdConverterFrom<EntityDomain>.FromString(workflow.DomainId);

        Data data = ToData(workflow.Data);

        UtcDateTime<SigningState> statusChangedAt = UtcDateTimeConverterFrom<SigningState>.FromUnspecifiedUtcDateTime(workflow.StatusChangedAt);

        SigningState state = SigningStateFactory.CreateFromDb(data.Stages, data.Status, statusChangedAt);

        ConcurrencyToken<SigningWorkflow> concurrencyToken =
            ConcurrencyTokenConverterFrom<SigningWorkflow>.FromUnspecifiedUtcDateTime(workflow.ConcurrencyToken);

        SigningWorkflow result =
            SigningWorkflowFactory.CreateFromDb(
                id,
                entityId,
                domainId,
                state,
                data.Parameters,
                data.ApplicationEvents,
                concurrencyToken);

        return result;
    }

    private static Data ToData(byte[] bytes)
    {
        SigningWorkflowDataDb data = SigningWorkflowDataDb.Parser.ParseFrom(bytes);

        SigningStatus status = SigningStatusDbConverter.ToDomain(data.Status);

        SigningStage[] stages = data.Stages.Select(SigningStageDbConverter.ToDomain).ToArray();

        SigningParameters parameters = SigningParametersDbConverter.ToDomain(data.Parameters);

        List<SigningApplicationEvent> applicationEvents = data.ApplicationEvents.Select(SigningApplicationEventDbToDomainConverter.ToDomain).ToList();

        var result = new Data(status, stages, parameters, applicationEvents);

        return result;
    }

    private readonly record struct Data(
        SigningStatus Status,
        SigningStage[] Stages,
        SigningParameters Parameters,
        List<SigningApplicationEvent> ApplicationEvents);
}
