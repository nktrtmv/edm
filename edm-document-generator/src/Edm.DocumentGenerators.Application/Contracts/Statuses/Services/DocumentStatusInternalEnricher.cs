using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Services;

internal sealed class DocumentStatusInternalEnricher
{
    internal DocumentStatusInternalEnricher(Dictionary<Id<DocumentStatus>, DocumentStatus> statusesById)
    {
        StatusesById = statusesById;
    }

    private Dictionary<Id<DocumentStatus>, DocumentStatus> StatusesById { get; }

    internal DocumentStatusInternal FromDomain(Id<DocumentStatus> statusId)
    {
        DocumentStatus? status = StatusesById.GetValueOrDefault(statusId);

        if (status is null)
        {
            throw new BusinessLogicApplicationException($"Status (id: {statusId}) is not found among document statuses!");
        }

        DocumentStatusInternal result = DocumentStatusInternalConverter.FromDomain(status);

        return result;
    }
}
