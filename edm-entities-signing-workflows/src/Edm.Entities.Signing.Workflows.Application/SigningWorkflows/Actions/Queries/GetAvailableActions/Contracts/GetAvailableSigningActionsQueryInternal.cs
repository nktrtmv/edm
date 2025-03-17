using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts;

public sealed class GetAvailableSigningActionsQueryInternal : IRequest<GetAvailableSigningActionsQueryInternalResponse>
{
    public GetAvailableSigningActionsQueryInternal(SigningActionContextInternal context)
    {
        Context = context;
    }

    internal SigningActionContextInternal Context { get; }
}
