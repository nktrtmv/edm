using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Statuses;

internal static class DocumentSigningStageStatusBffConverter
{
    internal static DocumentSigningStageStatusBff FromExternal(SigningWorkflowStageStatusExternal status)
    {
        var result = status switch
        {
            SigningWorkflowStageStatusExternal.NotStarted => DocumentSigningStageStatusBff.NotStarted,
            SigningWorkflowStageStatusExternal.InProgress => DocumentSigningStageStatusBff.InProgress,
            SigningWorkflowStageStatusExternal.Completed => DocumentSigningStageStatusBff.Completed,
            SigningWorkflowStageStatusExternal.Signed => DocumentSigningStageStatusBff.Signed,
            SigningWorkflowStageStatusExternal.Rejected => DocumentSigningStageStatusBff.Rejected,
            SigningWorkflowStageStatusExternal.ReturnedToRework => DocumentSigningStageStatusBff.ReturnedToRework,
            SigningWorkflowStageStatusExternal.Withdrawn => DocumentSigningStageStatusBff.Withdrawn,
            SigningWorkflowStageStatusExternal.Cancelled => DocumentSigningStageStatusBff.Cancelled,
            SigningWorkflowStageStatusExternal.Error => DocumentSigningStageStatusBff.Error,
            SigningWorkflowStageStatusExternal.Revocation => DocumentSigningStageStatusBff.Revocation,
            SigningWorkflowStageStatusExternal.Revoked => DocumentSigningStageStatusBff.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
