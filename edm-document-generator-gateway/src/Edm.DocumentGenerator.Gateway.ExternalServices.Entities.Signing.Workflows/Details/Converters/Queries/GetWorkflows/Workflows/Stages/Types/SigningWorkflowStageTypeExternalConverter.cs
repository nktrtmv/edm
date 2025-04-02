using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;

internal static class SigningWorkflowStageTypeExternalConverter
{
    internal static SigningWorkflowStageTypeExternal FromDto(SigningStageTypeDto type)
    {
        var result = type switch
        {
            SigningStageTypeDto.Self => SigningWorkflowStageTypeExternal.Self,
            SigningStageTypeDto.Contractor => SigningWorkflowStageTypeExternal.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
