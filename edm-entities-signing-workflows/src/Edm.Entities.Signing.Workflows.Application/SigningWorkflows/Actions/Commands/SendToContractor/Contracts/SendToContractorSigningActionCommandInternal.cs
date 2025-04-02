using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.SendToContractor.Contracts;

public sealed class SendToContractorSigningActionCommandInternal : IRequest
{
    public SendToContractorSigningActionCommandInternal(SigningActionContextInternal context)
    {
        Context = context;
    }

    internal SigningActionContextInternal Context { get; }
}
