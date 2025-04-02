using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.Types;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages;

public sealed class SigningStageDetailsInternal
{
    internal SigningStageDetailsInternal(
        SigningStageTypeInternal type,
        Id<UserInternal> executorId,
        SigningStageStateInternal state,
        string? completionComment,
        string id)
    {
        Type = type;
        ExecutorId = executorId;
        State = state;
        CompletionComment = completionComment;
        Id = id;
    }

    public SigningStageTypeInternal Type { get; }
    public Id<UserInternal> ExecutorId { get; }
    public SigningStageStateInternal State { get; }
    public string? CompletionComment { get; }
    public string Id { get; }
}
