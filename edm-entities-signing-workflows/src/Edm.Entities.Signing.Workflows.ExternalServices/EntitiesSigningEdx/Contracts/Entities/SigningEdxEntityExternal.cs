using Edm.Entities.Signing.Workflows.ExternalServices.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Entities;

public sealed class SigningEdxEntityExternal
{
    public SigningEdxEntityExternal(Id<EntityExternal> id, Id<EntityDomainExternal> domainId)
    {
        Id = id;
        DomainId = domainId;
    }

    public Id<EntityExternal> Id { get; }
    public Id<EntityDomainExternal> DomainId { get; }
}
