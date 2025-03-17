using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parties.Types;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parties;

internal static class SigningPartyDtoConverter
{
    internal static SigningPartyInternal ToInternal(SigningPartyDto party)
    {
        SigningPartyTypeInternal type = SigningPartyTypeDtoConverter.ToInternal(party.Type);

        Id<CompanyInternal> companyId = IdConverterFrom<CompanyInternal>.FromString(party.CompanyId);

        Id<UserInternal> executorId = IdConverterFrom<UserInternal>.FromString(party.ExecutorId);

        var result = new SigningPartyInternal(type, companyId, executorId);

        return result;
    }
}
