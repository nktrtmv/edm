using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;

public sealed class SigningParameters
{
    public SigningParameters(Id<User>? documentClerkId, SigningElectronicDetails? electronicDetails)
    {
        DocumentClerkId = documentClerkId;
        ElectronicDetails = electronicDetails;
    }

    public Id<User>? DocumentClerkId { get; }
    public SigningElectronicDetails? ElectronicDetails { get; }
}
