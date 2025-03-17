using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows;

internal static class SigningWorkflowExternalConverter
{
    internal static SigningWorkflowExternal FromDto(SigningWorkflowDto workflow)
    {
        SigningWorkflowStageExternal[] stages = workflow.Stages.Select(SigningWorkflowStageExternalConverter.FromDto).ToArray();

        var result = new SigningWorkflowExternal(workflow.Id, stages);

        return result;
    }
}
