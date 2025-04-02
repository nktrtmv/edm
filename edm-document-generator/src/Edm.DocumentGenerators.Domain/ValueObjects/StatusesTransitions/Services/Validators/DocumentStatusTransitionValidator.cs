using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.Services.Validators;

internal static class DocumentStatusTransitionValidator
{
    internal static void Validate(DocumentStatus from, DocumentStatus to)
    {
        if (from.Id == to.Id)
        {
            throw new BusinessLogicApplicationException("Status from = status to");
        }

        if (from.Type != to.Type)
        {
            return;
        }

        if (from.Type == DocumentStatusType.Completed)
        {
            throw new BusinessLogicApplicationException("Status transition from " + DocumentStatusType.Completed);
        }

        if (from.Type == DocumentStatusType.Cancelled)
        {
            throw new BusinessLogicApplicationException("Status transition from " + DocumentStatusType.Cancelled);
        }
    }
}
