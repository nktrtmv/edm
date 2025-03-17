using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.PutIntoEffect.Contracts;

public sealed class PutIntoEffectSigningActionCommandInternal : IRequest
{
    public PutIntoEffectSigningActionCommandInternal(SigningActionContextInternal context)
    {
        Context = context;
    }

    internal SigningActionContextInternal Context { get; }
}
