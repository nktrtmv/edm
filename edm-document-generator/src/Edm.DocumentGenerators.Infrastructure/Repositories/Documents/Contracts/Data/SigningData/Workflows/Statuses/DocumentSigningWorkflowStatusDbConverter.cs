using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.SigningData.Workflows.Statuses;

internal static class DocumentSigningWorkflowStatusDbConverter
{
    internal static DocumentSigningWorkflowStatusDb FromDomain(DocumentSigningWorkflowStatus status)
    {
        DocumentSigningWorkflowStatusDb result = status switch
        {
            DocumentSigningWorkflowStatus.InProgress => DocumentSigningWorkflowStatusDb.InProgress,
            DocumentSigningWorkflowStatus.Finished => DocumentSigningWorkflowStatusDb.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static DocumentSigningWorkflowStatus ToDomain(DocumentSigningWorkflowStatusDb status)
    {
        DocumentSigningWorkflowStatus result = status switch
        {
            DocumentSigningWorkflowStatusDb.InProgress => DocumentSigningWorkflowStatus.InProgress,
            DocumentSigningWorkflowStatusDb.Finished => DocumentSigningWorkflowStatus.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
