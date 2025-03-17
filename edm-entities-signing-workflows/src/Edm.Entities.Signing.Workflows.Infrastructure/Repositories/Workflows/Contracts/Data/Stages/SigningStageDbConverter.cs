using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.Parties;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.States;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages;

internal static class SigningStageDbConverter
{
    internal static SigningStageDb FromDomain(SigningStage stage)
    {
        var id = IdConverterTo.ToString(stage.Id);

        SigningPartyDb party = SigningPartyDbConverter.FromDomain(stage.Party);

        SigningStageStateDb state = SigningStageStateDbConverter.FromDomain(stage.State);

        string? completionComment = stage.CompletionComment;

        var result = new SigningStageDb
        {
            Id = id,
            Party = party,
            State = state,
            CompletionComment = completionComment
        };

        return result;
    }

    internal static SigningStage ToDomain(SigningStageDb stage)
    {
        Id<SigningStage> id = IdConverterFrom<SigningStage>.FromString(stage.Id);

        SigningParty parties = SigningPartyDbConverter.ToDomain(stage.Party);

        SigningStageState state = SigningStageStateDbConverter.ToDomain(stage.State);

        string? completionComment = stage.CompletionComment;

        SigningStage result = SigningStageFactory.CreateFromDb(id, parties, state, completionComment);

        return result;
    }
}
