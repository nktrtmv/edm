using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.SendToContractor.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.SendToContractor;

[UsedImplicitly]
internal sealed class SendToContractorSigningActionCommandInternalHandler : IRequestHandler<SendToContractorSigningActionCommandInternal>
{
    public SendToContractorSigningActionCommandInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task Handle(SendToContractorSigningActionCommandInternal request, CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.Context.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        SigningActionContext context = SigningActionContextInternalConverter.ToDomain(request.Context, workflow);

        SigningActionsProcessor.SendToContractor(context);

        await Workflows.Upsert(workflow, cancellationToken);
    }
}
