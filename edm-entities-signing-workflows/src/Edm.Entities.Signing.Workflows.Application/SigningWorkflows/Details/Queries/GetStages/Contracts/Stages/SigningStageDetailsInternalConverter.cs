using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.Types;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages;

internal static class SigningStageInternalConverter
{
    internal static SigningStageDetailsInternal FromDomain(SigningStage stage)
    {
        SigningStageTypeInternal stageType = SigningStageTypeInternalConverter.FromDomain(stage.Party.Type);

        Id<UserInternal> executorId = IdConverterFrom<UserInternal>.From(stage.Party.ExecutorId);

        SigningStageStateInternal state = SigningStageStateInternalConverter.FromDomain(stage.State);

        var result = new SigningStageDetailsInternal(stageType, executorId, state, stage.CompletionComment, stage.Id.ToString());

        return result;
    }
}
