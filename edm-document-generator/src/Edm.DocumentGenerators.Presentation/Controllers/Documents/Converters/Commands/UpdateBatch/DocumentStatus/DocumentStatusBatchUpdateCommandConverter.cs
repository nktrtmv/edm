using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.UpdateBatch.DocumentStatus;

internal static class DocumentStatusBatchUpdateCommandConverter
{
    public static DocumentStatusBatchUpdateCommandInternal ToInternal(DocumentStatusBatchUpdateCommand command)
    {
        var result = new DocumentStatusBatchUpdateCommandInternal(command.DomainId, command.DocumentsIds.ToArray(), command.CurrentUserId, command.NewStatusId);

        return result;
    }
}
