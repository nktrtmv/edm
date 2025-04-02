using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Types;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses.Types;

internal static class DocumentStatusTypeDtoConverter
{
    internal static DocumentStatusTypeExternal ToExternal(DocumentStatusTypeDto status)
    {
        DocumentStatusTypeExternal result = status switch
        {
            DocumentStatusTypeDto.Initial => DocumentStatusTypeExternal.Initial,
            DocumentStatusTypeDto.Backlog => DocumentStatusTypeExternal.Backlog,
            DocumentStatusTypeDto.Simple => DocumentStatusTypeExternal.Simple,
            DocumentStatusTypeDto.Approval => DocumentStatusTypeExternal.Approval,
            DocumentStatusTypeDto.Signing => DocumentStatusTypeExternal.Signing,
            DocumentStatusTypeDto.Completed => DocumentStatusTypeExternal.Completed,
            DocumentStatusTypeDto.Cancelled => DocumentStatusTypeExternal.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
