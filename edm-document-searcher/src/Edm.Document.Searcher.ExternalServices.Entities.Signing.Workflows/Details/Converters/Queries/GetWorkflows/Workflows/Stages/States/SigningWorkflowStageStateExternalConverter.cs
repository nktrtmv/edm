using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;
using Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.States.Statuses;

namespace Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.States;

internal static class SigningWorkflowStageStateExternalConverter
{
    internal static SigningWorkflowStageStateExternal FromDto(SigningStageStateDto state)
    {
        SigningWorkflowStageStatusExternal status = SigningWorkflowStageStatusExternalConverter.FromDto(state.Status);

        var statusChangedAt = state.StatusChangedAt.ToDateTime();

        var result = new SigningWorkflowStageStateExternal(status, statusChangedAt);

        return result;
    }
}
