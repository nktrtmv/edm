using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parties.Types;

internal static class SigningPartyTypeDtoConverter
{
    internal static SigningPartyTypeInternal ToInternal(SigningPartyTypeDto type)
    {
        SigningPartyTypeInternal result = type switch
        {
            SigningPartyTypeDto.Self => SigningPartyTypeInternal.Self,
            SigningPartyTypeDto.Contractor => SigningPartyTypeInternal.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
