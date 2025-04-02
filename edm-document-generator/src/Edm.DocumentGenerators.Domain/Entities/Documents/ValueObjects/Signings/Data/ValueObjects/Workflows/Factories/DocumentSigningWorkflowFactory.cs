using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.Factories;

public static class DocumentSigningWorkflowFactory
{
    public static DocumentSigningWorkflow CreateNew()
    {
        var id = Id<DocumentSigningWorkflow>.CreateNew();

        var result = new DocumentSigningWorkflow(id, DocumentSigningWorkflowStatus.InProgress, false);

        return result;
    }

    public static DocumentSigningWorkflow CreateFromDb(
        Id<DocumentSigningWorkflow> id,
        DocumentSigningWorkflowStatus status,
        bool isSelfSigned)
    {
        var result = new DocumentSigningWorkflow(id, status, isSelfSigned);

        return result;
    }
}
