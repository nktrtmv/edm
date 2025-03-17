using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Statuses;

internal static class SigningStatusDbFromDomainConverter
{
    internal static string FromDomain(SigningStage[] stages)
    {
        SigningStage? activeStage = stages.LastOrDefault(s => s.Status != SigningStageStatus.NotStarted);

        if (activeStage is null)
        {
            return "NotStarted";
        }

        string stage = activeStage.Party.Type is SigningPartyType.Self
            ? "Self"
            : "Contractor";

        var result = $"{activeStage.Status}/{stage}";

        return result;
    }
}
