using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;

public sealed class SigningParty
{
    internal SigningParty(SigningPartyType type, Id<Company> companyId, Id<User> executorId)
    {
        Type = type;
        CompanyId = companyId;
        ExecutorId = executorId;
    }

    public SigningPartyType Type { get; }
    public Id<Company> CompanyId { get; }
    public Id<User> ExecutorId { get; }
}
