using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;

public sealed class SigningStage
{
    internal SigningStage(Id<SigningStage> id, SigningParty party, SigningStageState state, string? completionComment)
    {
        Id = id;
        Party = party;
        State = state;
        CompletionComment = completionComment;
    }

    public Id<SigningStage> Id { get; }
    public SigningParty Party { get; private set; }
    public SigningStageState State { get; private set; }
    public string? CompletionComment { get; private set; }
    public SigningStageStatus Status => State.Status;

    public bool IsAborted => Status is
        SigningStageStatus.ReturnedToRework or
        SigningStageStatus.Withdrawn or
        SigningStageStatus.Cancelled;

    public bool IsActive => Status is not (
        SigningStageStatus.Signed or
        SigningStageStatus.ReturnedToRework or
        SigningStageStatus.Withdrawn or
        SigningStageStatus.Cancelled);

    public bool IsInProgress => Status is
        SigningStageStatus.NotStarted or
        SigningStageStatus.InProgress;

    public void SetState(SigningStageState state, string? completionComment = null)
    {
        State = state;
        CompletionComment = completionComment;
    }

    internal void SetParty(SigningParty party)
    {
        Party = party;
    }

    public override string ToString()
    {
        return $"id: {Id}, type: {Party.Type}, status: {Status}";
    }
}
