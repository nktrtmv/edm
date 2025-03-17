using Edm.Entities.Signing.Workflows.Application.SigningEdx.Events.DocumentsStatusChanged.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningEdx.Events.DocumentsStatusChanged;

[UsedImplicitly]
public sealed class DocumentsStatusChangedEventInternalHandler : IRequestHandler<DocumentsStatusChangedEventInternalCommand>
{
    public DocumentsStatusChangedEventInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task Handle(DocumentsStatusChangedEventInternalCommand request, CancellationToken cancellationToken)
    {
        SigningWorkflow workflow = await Workflows.GetRequired(request.WorkflowId, cancellationToken);

        if (IsProcessingShallBeSkipped(workflow))
        {
            return;
        }

        ElectronicSigningDocumentStatusChangeProcessor.Process(workflow, request.Status, request.Documents, request.Archives);

        await Workflows.Upsert(workflow, cancellationToken);
    }

    private static bool IsProcessingShallBeSkipped(SigningWorkflow workflow)
    {
        if (workflow.Status is SigningStatus.Completed)
        {
            return true;
        }

        return false;
    }
}
