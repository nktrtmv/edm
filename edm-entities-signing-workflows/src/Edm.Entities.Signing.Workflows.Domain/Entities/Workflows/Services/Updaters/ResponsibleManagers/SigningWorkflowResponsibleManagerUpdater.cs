using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Updaters.ResponsibleManagers;

public static class SigningWorkflowResponsibleManagerUpdater
{
    public static void Update(SigningWorkflow workflow, Id<User>? documentClerkId)
    {
        var updatedParameters = new SigningParameters(
            documentClerkId, workflow.Parameters.ElectronicDetails);

        workflow.SetParameters(updatedParameters);
    }
}
