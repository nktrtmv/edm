using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts.Contracts.DocumentsWithSignature;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts;

public sealed class SignSigningActionCommandInternal : IRequest
{
    public SignSigningActionCommandInternal(SigningActionContextInternal context, SigningDocumentWithSignatureInternal[] documents)
    {
        Context = context;
        Documents = documents;
    }

    internal SigningActionContextInternal Context { get; }
    internal SigningDocumentWithSignatureInternal[] Documents { get; }
}
