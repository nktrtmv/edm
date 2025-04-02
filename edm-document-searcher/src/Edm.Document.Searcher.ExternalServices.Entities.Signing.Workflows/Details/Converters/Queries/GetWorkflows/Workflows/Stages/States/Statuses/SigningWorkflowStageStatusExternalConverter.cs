using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.States.
    Statuses;

internal static class SigningWorkflowStageStatusExternalConverter
{
    internal static SigningWorkflowStageStatusExternal FromDto(SigningStageStatusDto status)
    {
        SigningWorkflowStageStatusExternal result = status switch
        {
            SigningStageStatusDto.NotStarted => SigningWorkflowStageStatusExternal.NotStarted,
            SigningStageStatusDto.InProgress => SigningWorkflowStageStatusExternal.InProgress,
            SigningStageStatusDto.Completed => SigningWorkflowStageStatusExternal.Completed,
            SigningStageStatusDto.Signed => SigningWorkflowStageStatusExternal.Signed,
            SigningStageStatusDto.Rejected => SigningWorkflowStageStatusExternal.Rejected,
            SigningStageStatusDto.ReturnedToRework => SigningWorkflowStageStatusExternal.ReturnedToRework,
            SigningStageStatusDto.Withdrawn => SigningWorkflowStageStatusExternal.Withdrawn,
            SigningStageStatusDto.Cancelled => SigningWorkflowStageStatusExternal.Cancelled,
            SigningStageStatusDto.Error => SigningWorkflowStageStatusExternal.Error,
            SigningStageStatusDto.Revocation => SigningWorkflowStageStatusExternal.Revocation,
            SigningStageStatusDto.Revoked => SigningWorkflowStageStatusExternal.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
