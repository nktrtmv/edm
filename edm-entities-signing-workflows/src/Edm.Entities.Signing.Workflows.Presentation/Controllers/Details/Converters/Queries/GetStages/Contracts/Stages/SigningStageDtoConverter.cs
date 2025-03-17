using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages.States;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages.Types;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages;

internal static class SigningStageDtoConverter
{
    internal static SigningStageDetailsDto FromInternal(SigningStageDetailsInternal stage)
    {
        SigningStageTypeDto stageType = SigningStageTypeDtoConverter.FromInternal(stage.Type);

        var executorId = IdConverterTo.ToString(stage.ExecutorId);

        SigningStageStateDto state = SigningStageStateDtoConverter.FromInternal(stage.State);

        var result = new SigningStageDetailsDto
        {
            StageType = stageType,
            ExecutorId = executorId,
            State = state,
            CompletionComment = stage.CompletionComment,
            Id = stage.Id
        };

        return result;
    }
}
