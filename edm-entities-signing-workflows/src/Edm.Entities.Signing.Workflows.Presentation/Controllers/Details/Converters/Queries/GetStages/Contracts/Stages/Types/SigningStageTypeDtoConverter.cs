using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages.Types;

internal static class SigningStageTypeDtoConverter
{
    internal static SigningStageTypeDto FromInternal(SigningStageTypeInternal type)
    {
        SigningStageTypeDto result = type switch
        {
            SigningStageTypeInternal.Self => SigningStageTypeDto.Self,
            SigningStageTypeInternal.Contractor => SigningStageTypeDto.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
