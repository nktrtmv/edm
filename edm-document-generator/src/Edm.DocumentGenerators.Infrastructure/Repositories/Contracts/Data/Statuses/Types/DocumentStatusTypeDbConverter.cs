using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Types;

internal static class DocumentStatusTypeDbConverter
{
    internal static DocumentStatusTypeDb FromDomain(DocumentStatusType type)
    {
        DocumentStatusTypeDb result = type switch
        {
            DocumentStatusType.Initial => DocumentStatusTypeDb.Initial,
            DocumentStatusType.Backlog => DocumentStatusTypeDb.Backlog,
            DocumentStatusType.Simple => DocumentStatusTypeDb.Simple,
            DocumentStatusType.Approval => DocumentStatusTypeDb.Approval,
            DocumentStatusType.Signing => DocumentStatusTypeDb.Signing,
            DocumentStatusType.Completed => DocumentStatusTypeDb.Completed,
            DocumentStatusType.Cancelled => DocumentStatusTypeDb.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStatusType ToDomain(DocumentStatusTypeDb type)
    {
        DocumentStatusType result = type switch
        {
            DocumentStatusTypeDb.Initial => DocumentStatusType.Initial,
            DocumentStatusTypeDb.Backlog => DocumentStatusType.Backlog,
            DocumentStatusTypeDb.Simple => DocumentStatusType.Simple,
            DocumentStatusTypeDb.Approval => DocumentStatusType.Approval,
            DocumentStatusTypeDb.Signing => DocumentStatusType.Signing,
            DocumentStatusTypeDb.Completed => DocumentStatusType.Completed,
            DocumentStatusTypeDb.Cancelled => DocumentStatusType.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
