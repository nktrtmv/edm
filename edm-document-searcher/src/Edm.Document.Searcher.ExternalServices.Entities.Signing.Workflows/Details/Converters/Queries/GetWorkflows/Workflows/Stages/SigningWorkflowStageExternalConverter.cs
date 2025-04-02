using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.States;
using Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;

namespace Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages;

internal static class SigningWorkflowStageExternalConverter
{
    internal static SigningWorkflowStageExternal FromDto(SigningStageDetailsDto stage)
    {
        SigningWorkflowStageTypeExternal stageType = SigningWorkflowStageTypeExternalConverter.FromDto(stage.StageType);

        SigningWorkflowStageStateExternal state = SigningWorkflowStageStateExternalConverter.FromDto(stage.State);

        var result = new SigningWorkflowStageExternal(
            stageType,
            stage.ExecutorId,
            state,
            stage.CompletionComment,
            stage.Id);

        return result;
    }
}
