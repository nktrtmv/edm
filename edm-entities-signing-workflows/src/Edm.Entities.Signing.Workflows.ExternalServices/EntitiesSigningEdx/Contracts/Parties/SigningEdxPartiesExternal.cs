using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Parties.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Parties;

public sealed class SigningEdxPartiesExternal
{
    public SigningEdxPartiesExternal(Id<CompanyExternal> contractorId, Id<CompanyExternal> selfId)
    {
        ContractorId = contractorId;
        SelfId = selfId;
    }

    public Id<CompanyExternal> ContractorId { get; }
    public Id<CompanyExternal> SelfId { get; }
}
