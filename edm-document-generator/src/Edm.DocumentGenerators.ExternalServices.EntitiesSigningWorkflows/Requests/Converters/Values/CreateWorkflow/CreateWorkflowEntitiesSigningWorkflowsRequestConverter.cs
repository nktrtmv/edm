using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parameters;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow.Parties;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values.CreateWorkflow;

internal static class CreateWorkflowEntitiesSigningWorkflowsRequestConverter
{
    internal static EntitiesSigningWorkflowsRequestsValue FromExternal(CreateWorkflowEntitiesSigningWorkflowsRequestExternal request)
    {
        var entityId = IdConverterTo.ToString(request.Document.Id);

        DocumentSigningWorkflow? workflow = request.Document.SigningData.Workflows.Last();

        var workflowId = IdConverterTo.ToString(workflow.Id);

        SigningParametersDto? parameters = EntitiesSigningWorkflowsParametersDtoConverter.FromDomain(request.Parameters);

        SigningPartyDto[] parties =
            request.Parties.Select(EntitiesSigningWorkflowsPartyDtoConverter.FromDomain).ToArray();

        var createWorkflow = new CreateWorkflowEntitiesSigningWorkflowRequest
        {
            EntityId = entityId,
            WorkflowId = workflowId,
            Parameters = parameters,
            Parties = { parties }
        };

        var result = new EntitiesSigningWorkflowsRequestsValue
        {
            DomainId = request.Document.DomainId.Value,
            CreateWorkflow = createWorkflow
        };

        return result;
    }
}
