using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.UpdateBatch.DocumentStatus;

internal static class DocumentStatusBatchUpdateCommandResponseConverter
{
    public static DocumentStatusBatchUpdateCommandResponse FromInternal(DocumentStatusBatchUpdateCommandInternalResponse response)
    {
        var result = new DocumentStatusBatchUpdateCommandResponse
        {
            UncompletedDocumentIds = { response.UncompletedDocumentIds }
        };

        return result;
    }
}
