using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawBySelf.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawBySelf;

[UsedImplicitly]
internal sealed class WithdrawBySelfSigningActionCommandInternalHandler : IRequestHandler<WithdrawBySelfSigningActionCommandInternal>
{
    public WithdrawBySelfSigningActionCommandInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task Handle(WithdrawBySelfSigningActionCommandInternal request, CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.Context.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        SigningActionContext context = SigningActionContextInternalConverter.ToDomain(request.Context, workflow);

        SigningActionsProcessor.WithdrawBySelf(context, request.Comment);

        await Workflows.Upsert(workflow, cancellationToken);
    }
}
