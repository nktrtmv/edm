using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.Parties.Types;

internal static class SigningPartyTypeDbConverter
{
    internal static SigningPartyTypeDb FromDomain(SigningPartyType type)
    {
        SigningPartyTypeDb result = type switch
        {
            SigningPartyType.Self => SigningPartyTypeDb.Self,
            SigningPartyType.Contractor => SigningPartyTypeDb.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static SigningPartyType ToDomain(SigningPartyTypeDb type)
    {
        SigningPartyType result = type switch
        {
            SigningPartyTypeDb.Self => SigningPartyType.Self,
            SigningPartyTypeDb.Contractor => SigningPartyType.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
