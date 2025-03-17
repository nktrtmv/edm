using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningEdx.Events.DocumentsStatusChanged.Contracts;

public sealed class DocumentsStatusChangedEventInternalCommand : IRequest
{
    public DocumentsStatusChangedEventInternalCommand(
        Id<SigningWorkflow> workflowId,
        SigningDocument[] documents,
        SigningArchive[] archives,
        SigningStageStatus status)
    {
        WorkflowId = workflowId;
        Documents = documents;
        Archives = archives;
        Status = status;
    }

    internal Id<SigningWorkflow> WorkflowId { get; }
    internal SigningDocument[] Documents { get; }
    internal SigningArchive[] Archives { get; }
    internal SigningStageStatus Status { get; }
}
