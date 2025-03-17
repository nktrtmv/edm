using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows.Statuses;

internal static class DocumentSigningWorkflowStatusInternalConverter
{
    internal static DocumentSigningWorkflowStatusInternal FromDomain(DocumentSigningWorkflowStatus status)
    {
        DocumentSigningWorkflowStatusInternal result = status switch
        {
            DocumentSigningWorkflowStatus.InProgress => DocumentSigningWorkflowStatusInternal.InProgress,
            DocumentSigningWorkflowStatus.Finished => DocumentSigningWorkflowStatusInternal.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
