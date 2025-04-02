using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;

internal static class SigningWorkflowStageTypeExternalConverter
{
    internal static SigningWorkflowStageTypeExternal FromDto(SigningStageTypeDto type)
    {
        SigningWorkflowStageTypeExternal result = type switch
        {
            SigningStageTypeDto.Self => SigningWorkflowStageTypeExternal.Self,
            SigningStageTypeDto.Contractor => SigningWorkflowStageTypeExternal.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
