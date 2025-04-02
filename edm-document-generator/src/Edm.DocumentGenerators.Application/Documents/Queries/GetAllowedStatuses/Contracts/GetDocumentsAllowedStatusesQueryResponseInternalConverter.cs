using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses.Contracts;

internal static class GetDocumentsAllowedStatusesQueryResponseInternalConverter
{
    public static GetDocumentsAllowedStatusesQueryResponseInternal FromDomain(HashSet<DocumentStatus> statuses)
    {
        DocumentStatusInternal[] statusesInternal = statuses.Select(DocumentStatusInternalConverter.FromDomain).ToArray();

        var result = new GetDocumentsAllowedStatusesQueryResponseInternal(statusesInternal);

        return result;
    }
}
