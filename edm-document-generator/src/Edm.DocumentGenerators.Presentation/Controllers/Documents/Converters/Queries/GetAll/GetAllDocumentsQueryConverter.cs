using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.GetAll.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.GetAll;

internal static class GetAllDocumentsQueryConverter
{
    internal static GetAllDocumentsQueryInternal ToInternal(GetAllDocumentsQuery query)
    {
        Id<DocumentInternal>[] documentsIds = query.DocumentsIds.Select(IdConverterFrom<DocumentInternal>.FromString).ToArray();

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(query.CurrentUserId);

        var result = new GetAllDocumentsQueryInternal(documentsIds, currentUserId, query.SkipProcessing);

        return result;
    }
}
