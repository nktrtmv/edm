using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.States.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.States;

internal static class SigningWorkflowStageStateExternalConverter
{
    internal static SigningWorkflowStageStateExternal FromDto(SigningStageStateDto state)
    {
        var status = SigningWorkflowStageStatusExternalConverter.FromDto(state.Status);

        var statusChangedAt = state.StatusChangedAt.ToDateTime();

        var result = new SigningWorkflowStageStateExternal(status, statusChangedAt);

        return result;
    }
}
