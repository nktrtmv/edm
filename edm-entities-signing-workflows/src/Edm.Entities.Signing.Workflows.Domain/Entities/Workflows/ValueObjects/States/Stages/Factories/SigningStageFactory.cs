using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.Factories;

public static class SigningStageFactory
{
    public static SigningStage CreateNew(SigningParty party)
    {
        var id = Id<SigningStage>.CreateNew();

        SigningStageState state = SigningStageStateFactory.CreateNew();

        SigningStage result = CreateFromDb(id, party, state, null);

        return result;
    }

    public static SigningStage CreateFromDb(
        Id<SigningStage> id,
        SigningParty party,
        SigningStageState state,
        string? completionComment)
    {
        var result = new SigningStage(id, party, state, completionComment);

        return result;
    }
}
