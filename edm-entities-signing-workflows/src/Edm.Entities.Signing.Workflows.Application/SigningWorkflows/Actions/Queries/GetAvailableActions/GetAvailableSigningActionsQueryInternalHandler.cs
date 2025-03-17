using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts.Contracts.ActionsTypes;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions;

[UsedImplicitly]
internal sealed class GetAvailableSigningActionsQueryInternalHandler
    : IRequestHandler<GetAvailableSigningActionsQueryInternal, GetAvailableSigningActionsQueryInternalResponse>
{
    public GetAvailableSigningActionsQueryInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task<GetAvailableSigningActionsQueryInternalResponse> Handle(GetAvailableSigningActionsQueryInternal request, CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.Context.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        SigningActionContext context = SigningActionContextInternalConverter.ToDomain(request.Context, workflow);

        SigningActionType[] actions = AvailableSigningActionsDetector.Detect(context);

        SigningActionTypeInternal[] actionsInternal = actions.Select(SigningActionTypeInternalConverter.FromDomain).ToArray();

        var result = new GetAvailableSigningActionsQueryInternalResponse(actionsInternal);

        return result;
    }
}
