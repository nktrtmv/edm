using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawByContractor.Contracts;

public sealed class WithdrawByContractorSigningActionCommandInternal : IRequest
{
    public WithdrawByContractorSigningActionCommandInternal(SigningActionContextInternal context, string comment)
    {
        Context = context;
        Comment = comment;
    }

    internal SigningActionContextInternal Context { get; }
    internal string Comment { get; }
}
