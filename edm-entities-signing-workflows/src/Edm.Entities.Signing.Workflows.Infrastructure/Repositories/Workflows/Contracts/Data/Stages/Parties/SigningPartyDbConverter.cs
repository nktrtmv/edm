using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.Parties.Types;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Stages.Parties;

internal static class SigningPartyDbConverter
{
    internal static SigningPartyDb FromDomain(SigningParty party)
    {
        SigningPartyTypeDb type = SigningPartyTypeDbConverter.FromDomain(party.Type);

        var companyId = IdConverterTo.ToString(party.CompanyId);

        var executorId = IdConverterTo.ToString(party.ExecutorId);

        var result = new SigningPartyDb
        {
            Type = type,
            CompanyId = companyId,
            ExecutorId = executorId
        };

        return result;
    }

    internal static SigningParty ToDomain(SigningPartyDb party)
    {
        SigningPartyType type = SigningPartyTypeDbConverter.ToDomain(party.Type);

        Id<Company> companyId = IdConverterFrom<Company>.FromString(party.CompanyId);

        Id<User> executorId = IdConverterFrom<User>.FromString(party.ExecutorId);

        SigningParty result = SigningPartyFactory.CreateFromDb(type, companyId, executorId);

        return result;
    }
}
