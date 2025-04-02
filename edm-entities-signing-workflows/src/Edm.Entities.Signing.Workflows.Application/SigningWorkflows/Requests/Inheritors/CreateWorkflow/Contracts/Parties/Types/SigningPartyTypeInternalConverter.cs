using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties.Types;

internal static class SigningPartyTypeInternalConverter
{
    internal static SigningPartyType ToDomain(SigningPartyTypeInternal type)
    {
        SigningPartyType result = type switch
        {
            SigningPartyTypeInternal.Self => SigningPartyType.Self,
            SigningPartyTypeInternal.Contractor => SigningPartyType.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
