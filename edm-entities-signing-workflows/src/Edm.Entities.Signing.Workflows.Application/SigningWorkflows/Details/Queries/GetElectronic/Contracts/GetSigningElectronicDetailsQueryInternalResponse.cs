using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts;

public sealed class GetSigningElectronicDetailsQueryInternalResponse
{
    internal GetSigningElectronicDetailsQueryInternalResponse(SigningElectronicDetailsInternal? details)
    {
        Details = details;
    }

    public SigningElectronicDetailsInternal? Details { get; }
}
