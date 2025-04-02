using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts.Factories;

internal static class ApprovalEnrichersContextFactory
{
    internal static ApprovalEnrichersContext Create(EntityTypeKeyBff entityTypeKey)
    {
        var entityTypeKeyExternal = EntityTypeKeyBffToExternalConverter.ToExternal(entityTypeKey);

        var result = new ApprovalEnrichersContext(entityTypeKeyExternal);

        return result;
    }
}
