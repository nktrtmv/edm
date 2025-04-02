using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.ReturnToRework.Contracts;

public sealed class ReturnToReworkSigningActionCommandInternal : IRequest
{
    public ReturnToReworkSigningActionCommandInternal(SigningActionContextInternal context, string comment)
    {
        Context = context;
        Comment = comment;
    }

    internal SigningActionContextInternal Context { get; }
    internal string Comment { get; }
}
