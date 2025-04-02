using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Types;

internal static class DocumentStatusTypeInternalConverter
{
    internal static DocumentStatusTypeInternal FromDomain(DocumentStatusType type)
    {
        DocumentStatusTypeInternal result = type switch
        {
            DocumentStatusType.Initial => DocumentStatusTypeInternal.Initial,
            DocumentStatusType.Backlog => DocumentStatusTypeInternal.Backlog,
            DocumentStatusType.Simple => DocumentStatusTypeInternal.Simple,
            DocumentStatusType.Approval => DocumentStatusTypeInternal.Approval,
            DocumentStatusType.Signing => DocumentStatusTypeInternal.Signing,
            DocumentStatusType.Completed => DocumentStatusTypeInternal.Completed,
            DocumentStatusType.Cancelled => DocumentStatusTypeInternal.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStatusType ToDomain(DocumentStatusTypeInternal type)
    {
        DocumentStatusType result = type switch
        {
            DocumentStatusTypeInternal.Initial => DocumentStatusType.Initial,
            DocumentStatusTypeInternal.Backlog => DocumentStatusType.Backlog,
            DocumentStatusTypeInternal.Simple => DocumentStatusType.Simple,
            DocumentStatusTypeInternal.Approval => DocumentStatusType.Approval,
            DocumentStatusTypeInternal.Signing => DocumentStatusType.Signing,
            DocumentStatusTypeInternal.Completed => DocumentStatusType.Completed,
            DocumentStatusTypeInternal.Cancelled => DocumentStatusType.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
