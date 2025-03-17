using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Signing;

internal static class DocumentSigningWorkflowsChecker
{
    internal static bool IsAlreadyProcessed(Document document, Id<DocumentSigningWorkflow> workflowId)
    {
        if (document.Status.Type != DocumentStatusType.Signing)
        {
            return true;
        }

        DocumentSigningWorkflow currentWorkflow = document.SigningData.Workflows.Last();

        if (currentWorkflow.Id != workflowId)
        {
            return true;
        }

        if (currentWorkflow.Status != DocumentSigningWorkflowStatus.InProgress)
        {
            return true;
        }

        return false;
    }
}
