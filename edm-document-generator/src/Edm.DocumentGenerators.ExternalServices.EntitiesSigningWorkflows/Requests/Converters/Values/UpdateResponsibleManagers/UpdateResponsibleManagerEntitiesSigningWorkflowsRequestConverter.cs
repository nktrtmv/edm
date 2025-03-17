using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateResponsibleManagers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.UpdateResponsibleManagers;

internal static class UpdateResponsibleManagerEntitiesSigningWorkflowsRequestConverter
{
    internal static EntitiesSigningWorkflowsRequestsValue FromExternal(UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternal request)
    {
        DocumentSigningWorkflow? workflow = request.Document.SigningData.Workflows.Last();

        var workflowId = IdConverterTo.ToString(workflow.Id);

        var responsibleManagerId = IdConverterTo.ToString(request.ResponsibleManagerId);

        var updateResponsibleManager = new UpdateResponsibleManagerEntitiesSigningWorkflowRequest
        {
            WorkflowId = workflowId,
            DocumentClerkId = responsibleManagerId
        };

        var result = new EntitiesSigningWorkflowsRequestsValue
        {
            DomainId = request.Document.DomainId.Value,
            UpdateResponsibleManager = updateResponsibleManager
        };

        return result;
    }
}
