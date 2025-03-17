using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Routes;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules;

public interface IEntitiesApprovalRulesClient
{
    Task UpsertEntityType(
        EntitiesApprovalRuleEntityTypeExternal entityType,
        string currentUserId,
        CancellationToken cancellationToken);

    Task DeleteEntityType(
        EntitiesApprovalRuleEntityTypeKeyExternal entityTypeKey,
        Id<User> currentUserId,
        CancellationToken cancellationToken);

    Task<EntitiesApprovalRuleRouteExternal> FindRoute(
        EntitiesApprovalRuleEntityExternal entity,
        string approvalGraphTag,
        CancellationToken cancellationToken);

    Task ValidateThereAreActiveApprovalRuleGraphs(
        EntitiesApprovalRuleEntityTypeKeyExternal entityTypekey,
        string[] approvalGraphsTags,
        CancellationToken cancellationToken);
}
