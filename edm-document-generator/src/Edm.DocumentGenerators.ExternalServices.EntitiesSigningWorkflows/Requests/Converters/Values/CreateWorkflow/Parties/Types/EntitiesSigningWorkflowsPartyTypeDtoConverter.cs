using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parties.Types;

internal static class EntitiesSigningWorkflowsPartyTypeDtoConverter
{
    internal static SigningPartyTypeDto FromDomain(DocumentPartyType type)
    {
        SigningPartyTypeDto result = type switch
        {
            DocumentPartyType.Self => SigningPartyTypeDto.Self,
            DocumentPartyType.Contractor => SigningPartyTypeDto.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
