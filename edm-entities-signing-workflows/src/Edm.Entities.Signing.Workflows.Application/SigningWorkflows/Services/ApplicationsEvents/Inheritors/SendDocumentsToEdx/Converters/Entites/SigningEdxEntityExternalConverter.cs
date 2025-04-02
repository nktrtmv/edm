using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Entities;
using Edm.Entities.Signing.Workflows.ExternalServices.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Entites;

internal static class SigningEdxEntityExternalConverter
{
    internal static SigningEdxEntityExternal FromDomain(SigningWorkflow workflow)
    {
        Id<EntityExternal> entityId = IdConverterFrom<EntityExternal>.From(workflow.EntityId);

        Id<EntityDomainExternal> domainId = IdConverterFrom<EntityDomainExternal>.From(workflow.DomainId);

        var result = new SigningEdxEntityExternal(entityId, domainId);

        return result;
    }
}
