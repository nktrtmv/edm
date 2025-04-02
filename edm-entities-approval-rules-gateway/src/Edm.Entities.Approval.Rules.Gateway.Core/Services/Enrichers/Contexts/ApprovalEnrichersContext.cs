using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Contracts.EntityTypesKeys;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;

public sealed class ApprovalEnrichersContext : EnrichersContext
{
    internal ApprovalEnrichersContext(EntityTypeKeyExternal entityTypeKey)
    {
        EntityTypeKey = entityTypeKey;
    }

    internal EntityTypeKeyExternal EntityTypeKey { get; }
}
