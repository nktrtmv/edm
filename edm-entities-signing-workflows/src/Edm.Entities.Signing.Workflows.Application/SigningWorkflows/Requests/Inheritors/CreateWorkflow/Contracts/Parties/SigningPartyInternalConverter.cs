using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties.Types;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties;

internal static class SigningPartyInternalConverter
{
    internal static SigningParty ToDomain(SigningPartyInternal party)
    {
        SigningPartyType type = SigningPartyTypeInternalConverter.ToDomain(party.Type);

        Id<Company> companyId = IdConverterFrom<Company>.From(party.CompanyId);

        Id<User> executorId = IdConverterFrom<User>.From(party.ExecutorId);

        SigningParty result = SigningPartyFactory.CreateFrom(type, companyId, executorId);

        return result;
    }
}
