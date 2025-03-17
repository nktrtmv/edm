using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Cancel.Contracts;

public sealed class CancelSigningActionCommandInternal : IRequest
{
    public CancelSigningActionCommandInternal(SigningActionContextInternal context, string comment)
    {
        Context = context;
        Comment = comment;
    }

    internal SigningActionContextInternal Context { get; }
    internal string Comment { get; }
}
