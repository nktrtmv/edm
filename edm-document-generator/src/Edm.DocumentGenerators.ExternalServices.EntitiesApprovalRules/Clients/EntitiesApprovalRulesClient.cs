using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.DeleteEntityType;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute.Routes;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.ValidateThereAreActiveGraphs;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Routes;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients;

internal sealed class EntitiesApprovalRulesClient(ApprovalRulesService.ApprovalRulesServiceClient client, ILogger<EntitiesApprovalRulesClient> logger)
    : IEntitiesApprovalRulesClient
{
    public async Task UpsertEntityType(EntitiesApprovalRuleEntityTypeExternal entityType, string currentUserId, CancellationToken cancellationToken)
    {
        UpsertEntityTypeApprovalRulesCommand? command =
            UpsertEntityTypeEntitiesApprovalRulesCommandConverter.FromDomain(entityType, currentUserId);

        await TracingFacility.TraceGrpc(
            logger,
            nameof(client.UpsertEntityTypeAsync),
            command,
            async () => await client.UpsertEntityTypeAsync(command, cancellationToken: cancellationToken));
    }

    public async Task DeleteEntityType(EntitiesApprovalRuleEntityTypeKeyExternal entityTypeKey, Id<User> currentUserId, CancellationToken cancellationToken)
    {
        DeleteEntityTypeApprovalRulesCommand? command = DeleteEntityTypeEntitiesApprovalRulesCommandConverter.FromExternal(entityTypeKey, currentUserId);

        await TracingFacility.TraceGrpc(
            logger,
            nameof(client.DeleteEntityType),
            command,
            async () => await client.DeleteEntityTypeAsync(command, cancellationToken: cancellationToken));
    }

    public async Task ValidateThereAreActiveApprovalRuleGraphs(
        EntitiesApprovalRuleEntityTypeKeyExternal entityTypekey,
        string[] approvalGraphsTags,
        CancellationToken cancellationToken)
    {
        ValidateThereAreActiveGraphsApprovalRulesQuery? query =
            ValidateThereAreActiveGraphsEntitiesApprovalRulesQueryConverter.FromDomain(entityTypekey, approvalGraphsTags);

        await TracingFacility.TraceGrpc(
            logger,
            nameof(client.ValidateThereAreActiveGraphsAsync),
            query,
            async () => await client.ValidateThereAreActiveGraphsAsync(query, cancellationToken: cancellationToken));
    }

    public async Task<EntitiesApprovalRuleRouteExternal> FindRoute(
        EntitiesApprovalRuleEntityExternal entity,
        string approvalGraphTag,
        CancellationToken cancellationToken)
    {
        FindRouteApprovalRulesQuery? query =
            FindRouteEntitiesApprovalRulesQueryConverter.FromExternal(entity, approvalGraphTag);

        FindRouteApprovalRulesQueryResponse? response = await TracingFacility.TraceGrpc(
            logger,
            nameof(client.FindRouteAsync),
            query,
            async () => await client.FindRouteAsync(query, cancellationToken: cancellationToken));

        EntitiesApprovalRuleRouteExternal? result =
            EntitiesApprovalRuleRouteDtoConverter.ToExternal(response);

        return result;
    }
}
