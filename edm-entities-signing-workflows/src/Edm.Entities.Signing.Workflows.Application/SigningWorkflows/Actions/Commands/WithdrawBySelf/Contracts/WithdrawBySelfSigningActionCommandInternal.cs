using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawBySelf.Contracts;

public sealed class WithdrawBySelfSigningActionCommandInternal : IRequest
{
    public WithdrawBySelfSigningActionCommandInternal(SigningActionContextInternal context, string comment)
    {
        Context = context;
        Comment = comment;
    }

    internal SigningActionContextInternal Context { get; }
    internal string Comment { get; }
}
