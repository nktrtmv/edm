using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parties.Types;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parties;

internal static class EntitiesSigningWorkflowsPartyDtoConverter
{
    internal static SigningPartyDto FromDomain(DocumentSigningParty signingParty)
    {
        var companyId = IdConverterTo.ToString(signingParty.Party.Id);

        SigningPartyTypeDto type = EntitiesSigningWorkflowsPartyTypeDtoConverter.FromDomain(signingParty.Party.Type);

        var executorId = IdConverterTo.ToString(signingParty.ExecutorId);

        var result = new SigningPartyDto
        {
            CompanyId = companyId,
            Type = type,
            ExecutorId = executorId
        };

        return result;
    }
}
