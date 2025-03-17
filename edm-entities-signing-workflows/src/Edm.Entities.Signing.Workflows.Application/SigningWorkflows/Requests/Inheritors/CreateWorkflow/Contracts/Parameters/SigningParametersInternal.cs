using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Electronics;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;

public sealed class SigningParametersInternal
{
    public SigningParametersInternal(Id<UserInternal>? documentClerkId, SigningElectronicParametersInternal? electronicDetails)
    {
        DocumentClerkId = documentClerkId;
        ElectronicDetails = electronicDetails;
    }

    internal Id<UserInternal>? DocumentClerkId { get; }
    internal SigningElectronicParametersInternal? ElectronicDetails { get; }
}
