using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Statuses;

internal static class DocumentSigningStageStatusInternalConverter
{
    internal static DocumentSigningStageStatusInternal FromExternal(SigningWorkflowStageStatusExternal status)
    {
        DocumentSigningStageStatusInternal result = status switch
        {
            SigningWorkflowStageStatusExternal.NotStarted => DocumentSigningStageStatusInternal.NotStarted,
            SigningWorkflowStageStatusExternal.InProgress => DocumentSigningStageStatusInternal.InProgress,
            SigningWorkflowStageStatusExternal.Completed => DocumentSigningStageStatusInternal.Completed,
            SigningWorkflowStageStatusExternal.Signed => DocumentSigningStageStatusInternal.Signed,
            SigningWorkflowStageStatusExternal.Rejected => DocumentSigningStageStatusInternal.Rejected,
            SigningWorkflowStageStatusExternal.ReturnedToRework => DocumentSigningStageStatusInternal.ReturnedToRework,
            SigningWorkflowStageStatusExternal.Withdrawn => DocumentSigningStageStatusInternal.Withdrawn,
            SigningWorkflowStageStatusExternal.Cancelled => DocumentSigningStageStatusInternal.Cancelled,
            SigningWorkflowStageStatusExternal.Error => DocumentSigningStageStatusInternal.Error,
            SigningWorkflowStageStatusExternal.Revocation => DocumentSigningStageStatusInternal.Revocation,
            SigningWorkflowStageStatusExternal.Revoked => DocumentSigningStageStatusInternal.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
