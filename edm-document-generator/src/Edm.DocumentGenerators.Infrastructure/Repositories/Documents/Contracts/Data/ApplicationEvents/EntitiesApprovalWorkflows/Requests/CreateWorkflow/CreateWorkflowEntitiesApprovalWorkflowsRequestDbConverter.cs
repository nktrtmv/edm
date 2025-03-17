using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Markers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Options;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Options;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Parameters;

using Google.Protobuf;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.CreateWorkflow;

internal static class CreateWorkflowEntitiesApprovalWorkflowsRequestDbConverter
{
    internal static CreateWorkflowEntitiesApprovalWorkflowsRequestDb FromDomain(CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent request)
    {
        CreateWorkflowEntitiesApprovalWorkflowsRequestOptionsDb options =
            CreateWorkflowEntitiesApprovalWorkflowsRequestOptionsDbConverter.FromDomain(request.Options);

        CreateWorkflowEntitiesApprovalWorkflowsRequestParametersDb parameters =
            CreateWorkflowEntitiesApprovalWorkflowsRequestParametersDbConverter.FromDomain(request.Parameters);

        var currentUserId = IdConverterTo.ToString(request.CurrentUserId);

        ByteString route = BytesConverterTo.ToBytesString(request.FindRouteResponse!);

        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequestDb
        {
            Options = options,
            Parameters = parameters,
            CurrentUserId = currentUserId,
            Route = route
        };

        return result;
    }

    internal static CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent ToDomain(CreateWorkflowEntitiesApprovalWorkflowsRequestDb request)
    {
        DocumentApprovalOptions options =
            CreateWorkflowEntitiesApprovalWorkflowsRequestOptionsDbConverter.ToDomain(request.Options);

        DocumentApprovalParameters parameters =
            CreateWorkflowEntitiesApprovalWorkflowsRequestParametersDbConverter.ToDomain(request.Parameters);

        Id<User> currentUserId = IdConverterFrom<User>.FromString(request.CurrentUserId);

        Bytes<DocumentApprovalRoute> route = BytesConverterFrom<DocumentApprovalRoute>.FromByteString(request.Route!);

        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(
            parameters,
            options,
            currentUserId,
            route);

        return result;
    }
}
