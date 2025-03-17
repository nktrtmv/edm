using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;

internal static class DocumentClerkBatchUpdateCommandInternalResponseConverter
{
    public static DocumentClerkBatchUpdateCommandInternalResponse ToInternal(List<Id<Document>> ids)
    {
        Id<DocumentInternal>[] internalIds = ids.Select(IdConverterFrom<DocumentInternal>.From).ToArray();

        var result = new DocumentClerkBatchUpdateCommandInternalResponse(internalIds);

        return result;
    }
}
