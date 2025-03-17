using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Routes;

[UsedImplicitly]
public sealed class EntitiesApprovalRuleRouteExternal
{
    public EntitiesApprovalRuleRouteExternal(Bytes<EntitiesApprovalRuleRouteExternal> findRouteResponse)
    {
        FindRouteResponse = findRouteResponse;
    }

    public Bytes<EntitiesApprovalRuleRouteExternal> FindRouteResponse { get; }
}
