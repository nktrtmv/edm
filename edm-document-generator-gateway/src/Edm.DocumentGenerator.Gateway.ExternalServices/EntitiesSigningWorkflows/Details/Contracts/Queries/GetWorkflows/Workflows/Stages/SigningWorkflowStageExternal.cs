using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;

public sealed class SigningWorkflowStageExternal
{
    public SigningWorkflowStageExternal(
        SigningWorkflowStageTypeExternal stageType,
        string executorId,
        SigningWorkflowStageStateExternal state,
        string? completionComment)
    {
        StageType = stageType;
        ExecutorId = executorId;
        State = state;
        CompletionComment = completionComment;
    }

    public SigningWorkflowStageTypeExternal StageType { get; }
    public string ExecutorId { get; }
    public SigningWorkflowStageStateExternal State { get; }
    public string? CompletionComment { get; }
}
