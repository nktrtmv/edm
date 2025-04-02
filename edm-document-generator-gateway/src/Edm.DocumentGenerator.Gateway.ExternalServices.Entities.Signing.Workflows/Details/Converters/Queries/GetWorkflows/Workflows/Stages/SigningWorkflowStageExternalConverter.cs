using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.States;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages;

internal static class SigningWorkflowStageExternalConverter
{
    internal static SigningWorkflowStageExternal FromDto(SigningStageDetailsDto stage)
    {
        var stageType = SigningWorkflowStageTypeExternalConverter.FromDto(stage.StageType);

        var state = SigningWorkflowStageStateExternalConverter.FromDto(stage.State);

        var result = new SigningWorkflowStageExternal(
            stageType,
            stage.ExecutorId,
            state,
            stage.CompletionComment);

        return result;
    }
}
