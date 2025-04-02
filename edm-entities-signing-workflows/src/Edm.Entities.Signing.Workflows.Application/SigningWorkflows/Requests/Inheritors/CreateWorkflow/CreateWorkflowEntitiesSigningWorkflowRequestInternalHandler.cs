using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow;

[UsedImplicitly]
internal sealed class CreateWorkflowEntitiesSigningWorkflowRequestInternalHandler : IRequestHandler<CreateWorkflowEntitiesSigningWorkflowRequestInternal>
{
    public CreateWorkflowEntitiesSigningWorkflowRequestInternalHandler(
        SigningWorkflowsFacade workflows,
        ILogger<CreateWorkflowEntitiesSigningWorkflowRequestInternalHandler> logger)
    {
        Workflows = workflows;
        Logger = logger;
    }

    private SigningWorkflowsFacade Workflows { get; }
    private ILogger<CreateWorkflowEntitiesSigningWorkflowRequestInternalHandler> Logger { get; }

    public async Task Handle(CreateWorkflowEntitiesSigningWorkflowRequestInternal request, CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.WorkflowId);

        SigningWorkflow? existingWorkflow = await Workflows.Get(workflowId, cancellationToken);

        if (existingWorkflow is not null)
        {
            return;
        }

        Id<Entity> entityId = IdConverterFrom<Entity>.From(request.EntityId);

        Id<EntityDomain> domainId = IdConverterFrom<EntityDomain>.From(request.DomainId);

        SigningParty[] parties = request.Parties.Select(SigningPartyInternalConverter.ToDomain).ToArray();

        SigningParameters parameters = SigningParametersInternalConverter.ToDomain(request.Parameters);

        SigningWorkflow workflow = SigningWorkflowFactory.CreateNew(workflowId, entityId, domainId, parties, parameters);

        await Workflows.Upsert(workflow, cancellationToken);
    }
}
