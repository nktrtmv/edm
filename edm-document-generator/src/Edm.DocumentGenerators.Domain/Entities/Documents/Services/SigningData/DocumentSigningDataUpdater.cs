using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.SigningData;

public static class DocumentSigningDataUpdater
{
    public static bool TryUpdateSelfSigned(Document document, Id<DocumentSigningWorkflow> signingId)
    {
        DocumentSigningWorkflow? workflow = document.SigningData.Workflows.LastOrDefault(d => d.Id == signingId);

        if (workflow is null)
        {
            return false;
        }

        if (workflow.IsSelfSigned)
        {
            return false;
        }

        workflow.SetIsSelfSigned();

        return true;
    }
}
