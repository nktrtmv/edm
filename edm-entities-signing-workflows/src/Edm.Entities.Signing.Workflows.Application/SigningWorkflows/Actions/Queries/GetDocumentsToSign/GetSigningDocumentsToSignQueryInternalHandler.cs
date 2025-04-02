using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts.Contracts.DocumentsToSign;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign;

[UsedImplicitly]
internal sealed class GetSigningDocumentsToSignQueryInternalHandler
    : IRequestHandler<GetSigningDocumentsToSignQueryInternal, GetSigningDocumentsToSignQueryInternalResponse>
{
    public GetSigningDocumentsToSignQueryInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task<GetSigningDocumentsToSignQueryInternalResponse> Handle(GetSigningDocumentsToSignQueryInternal request, CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.Context.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        if (workflow.Parameters.ElectronicDetails is null)
        {
            throw new InvalidOperationException($"Electronic details for signing workflow (id: {workflowId}) are not found.");
        }

        SigningDocumentToSignInternal[] documents =
            workflow.Parameters.ElectronicDetails.Documents.Select(SigningDocumentToSignInternalConverter.FromDomain).ToArray();

        var result = new GetSigningDocumentsToSignQueryInternalResponse(documents);

        return result;
    }
}
