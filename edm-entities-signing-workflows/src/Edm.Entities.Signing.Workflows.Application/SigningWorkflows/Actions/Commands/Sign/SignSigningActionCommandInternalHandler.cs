using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts.Contracts.DocumentsWithSignature;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign;

[UsedImplicitly]
internal sealed class SignSigningActionCommandInternalHandler : IRequestHandler<SignSigningActionCommandInternal>
{
    public SignSigningActionCommandInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task Handle(SignSigningActionCommandInternal request, CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.Context.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        SigningActionContext context = SigningActionContextInternalConverter.ToDomain(request.Context, workflow);

        Dictionary<Id<Attachment>, Id<Attachment>> documentsWithSignatures =
            request.Documents.Select(SigningDocumentWithSignatureInternalConverter.ToDomain).ToDictionary(x => x.Key, x => x.Value);

        SigningActionsProcessor.Sign(context, documentsWithSignatures);

        await Workflows.Upsert(workflow, cancellationToken);
    }
}
