using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Types;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;

internal static class DocumentStatusTypeInternalConverter
{
    internal static DocumentStatusTypeInternal FromExternal(DocumentStatusTypeExternal type)
    {
        DocumentStatusTypeInternal result = type switch
        {
            DocumentStatusTypeExternal.Initial => DocumentStatusTypeInternal.Initial,
            DocumentStatusTypeExternal.Backlog => DocumentStatusTypeInternal.Backlog,
            DocumentStatusTypeExternal.Simple => DocumentStatusTypeInternal.Simple,
            DocumentStatusTypeExternal.Approval => DocumentStatusTypeInternal.Approval,
            DocumentStatusTypeExternal.Signing => DocumentStatusTypeInternal.Signing,
            DocumentStatusTypeExternal.Completed => DocumentStatusTypeInternal.Completed,
            DocumentStatusTypeExternal.Cancelled => DocumentStatusTypeInternal.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
