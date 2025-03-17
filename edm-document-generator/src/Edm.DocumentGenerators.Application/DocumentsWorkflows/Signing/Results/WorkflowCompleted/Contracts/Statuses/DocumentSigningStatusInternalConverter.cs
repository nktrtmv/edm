using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts.Statuses;

internal static class DocumentSigningStatusInternalConverter
{
    internal static DocumentSigningStatus ToDomain(DocumentSigningStatusInternal status)
    {
        DocumentSigningStatus result = status switch
        {
            DocumentSigningStatusInternal.Signed => DocumentSigningStatus.Signed,
            DocumentSigningStatusInternal.Cancelled => DocumentSigningStatus.Cancelled,
            DocumentSigningStatusInternal.ToPreparation => DocumentSigningStatus.ToPreparation,
            DocumentSigningStatusInternal.ReturnedToRework => DocumentSigningStatus.ReturnedToRework,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
