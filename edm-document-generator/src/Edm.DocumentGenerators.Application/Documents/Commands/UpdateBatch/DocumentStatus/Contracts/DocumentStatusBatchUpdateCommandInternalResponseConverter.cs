using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;

internal static class DocumentStatusBatchUpdateCommandInternalResponseConverter
{
    public static DocumentStatusBatchUpdateCommandInternalResponse ToInternal(Id<Document>[] ids)
    {
        string[] documentIds = ids.Select(IdConverterTo.ToString).ToArray();

        var result = new DocumentStatusBatchUpdateCommandInternalResponse(documentIds);

        return result;
    }
}
