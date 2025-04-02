using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.DocumentsWithSignatures;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;

public interface ISigningWorkflowsActionsClient
{
    Task<GetDocumentsToSignSigningWorkflowActionQueryResponseExternal> GetDocumentsToSign(
        GetDocumentsToSignSigningWorkflowActionQueryExternal query,
        CancellationToken cancellationToken);

    Task Cancel(SigningWorkflowActionContextExternal context, string comment, CancellationToken cancellationToken);
    Task PutIntoEffect(SigningWorkflowActionContextExternal context, CancellationToken cancellationToken);
    Task ReturnToRework(SigningWorkflowActionContextExternal context, string comment, CancellationToken cancellationToken);
    Task SendToContractor(SigningWorkflowActionContextExternal context, CancellationToken cancellationToken);
    Task Sign(SigningWorkflowActionContextExternal context, SigningWorkflowDocumentWithSignatureExternal[] documents, CancellationToken cancellationToken);
    Task WithdrawByContractor(SigningWorkflowActionContextExternal context, string comment, CancellationToken cancellationToken);
    Task WithdrawBySelf(SigningWorkflowActionContextExternal context, string comment, CancellationToken cancellationToken);
}
