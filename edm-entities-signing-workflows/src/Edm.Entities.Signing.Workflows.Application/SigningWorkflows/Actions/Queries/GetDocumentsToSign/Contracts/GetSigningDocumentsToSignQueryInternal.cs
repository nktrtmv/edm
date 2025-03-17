using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts;

public sealed class GetSigningDocumentsToSignQueryInternal : IRequest<GetSigningDocumentsToSignQueryInternalResponse>
{
    public GetSigningDocumentsToSignQueryInternal(SigningActionContextInternal context)
    {
        Context = context;
    }

    internal SigningActionContextInternal Context { get; }
}
