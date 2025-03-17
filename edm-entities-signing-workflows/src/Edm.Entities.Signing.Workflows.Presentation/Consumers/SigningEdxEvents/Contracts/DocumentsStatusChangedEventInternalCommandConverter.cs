using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningEdx.Events.DocumentsStatusChanged.Contracts;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Archives;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Documents;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Statuses;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts;

internal static class DocumentsStatusChangedEventInternalCommandConverter
{
    internal static DocumentsStatusChangedEventInternalCommand FromDto(DocumentsStatusChangedSigningEdxEventDto request)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.FromString(request.SigningId);

        SigningArchive[] archives = request.Archives.Select(SigningEdxArchivesDtoConverter.ToDomain).ToArray();

        SigningDocument[] documents = request.Documents.Select(SigningEdxDocumentDetailsDtoConverter.ToDomain).ToArray();

        SigningStageStatus status = SigningEdxStatusDtoConverter.ToDomain(request.Status);

        var result = new DocumentsStatusChangedEventInternalCommand(workflowId, documents, archives, status);

        return result;
    }
}
