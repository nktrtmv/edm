using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Factories;

public static class SigningPartyFactory
{
    public static SigningParty CreateFrom(SigningPartyType type, Id<Company> companyId, Id<User> executorId)
    {
        SigningParty result = CreateFromDb(type, companyId, executorId);

        return result;
    }

    public static SigningParty CreateFromDb(SigningPartyType type, Id<Company> companyId, Id<User> executorId)
    {
        var result = new SigningParty(type, companyId, executorId);

        return result;
    }
}
