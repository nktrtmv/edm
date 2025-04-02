using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.Types;

internal static class SigningStageTypeInternalConverter
{
    internal static SigningStageTypeInternal FromDomain(SigningPartyType type)
    {
        SigningStageTypeInternal result = type switch
        {
            SigningPartyType.Self => SigningStageTypeInternal.Self,
            SigningPartyType.Contractor => SigningStageTypeInternal.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
