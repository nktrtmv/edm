using Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.UpdateBatch.DocumentClerk;

internal static class DocumentClerkBatchUpdateCommandResponseConverter
{
    public static DocumentClerkBatchUpdateCommandResponse FromInternal(DocumentClerkBatchUpdateCommandInternalResponse internalResponse)
    {
        string[] ids = internalResponse.DocumentIds.Select(IdConverterTo.ToString).ToArray();

        var result = new DocumentClerkBatchUpdateCommandResponse
        {
            UncompletedDocumentIds = { ids }
        };

        return result;
    }
}
