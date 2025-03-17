using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Keys;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Contexts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources.Generics;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources.Generics.SingleKey;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions;

internal sealed class AttributesPermissionsEnricherSource
    : SingleKeyEnricherSourceGeneric<IAttributesUserPermissionsCollector[], AttributesPermissionsEnricherKey,
        Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>>
{
    public AttributesPermissionsEnricherSource(
        IEnumerable<IAttributesUserPermissionsCollector> client,
        ILogger<EnricherSourceGeneric<IAttributesUserPermissionsCollector[], AttributesPermissionsEnricherKey,
            Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>>> logger) : base(client.ToArray(), logger)
    {
    }

    protected override async Task<Dictionary<AttributesPermissionsEnricherKey, Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>>> GetValues(
        AttributesPermissionsEnricherKey[] keys,
        CancellationToken cancellationToken)
    {
        IEnumerable<Task<SearchAttributesPermissionsResult>> tasks = keys.Select(key => CollectValues(key, cancellationToken));

        SearchAttributesPermissionsResult[] values = await Task.WhenAll(tasks);

        Dictionary<AttributesPermissionsEnricherKey, Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>> result = values.ToDictionary(
            v => v.Key,
            v => v.Permissions);

        return result;
    }

    private async Task<SearchAttributesPermissionsResult> CollectValues(
        AttributesPermissionsEnricherKey key,
        CancellationToken cancellationToken)
    {
        var permissions = new Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>();

        var collectorsContext = new AttributesUserPermissionsCollectorContext(key.Document, key.Workflows, key.User);

        foreach (var collector in Client)
        {
            Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> collectedPermissions = await collector.Collect(
                key.AttributesValues,
                collectorsContext,
                cancellationToken);

            ConcatPermissions(permissions, collectedPermissions);
        }

        var result = new SearchAttributesPermissionsResult(key, permissions);

        return result;
    }

    private static void ConcatPermissions(
        Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> permissions,
        Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> collectedPermissions)
    {
        foreach (KeyValuePair<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> collectedPermission in collectedPermissions)
        {
            var attributePermission = permissions.GetValueOrDefault(collectedPermission.Key);

            permissions[collectedPermission.Key] = attributePermission is null
                ? collectedPermission.Value
                : permissions[collectedPermission.Key]
                    .Concat(collectedPermission.Value)
                    .Distinct()
                    .ToArray();
        }
    }

    private sealed record SearchAttributesPermissionsResult(
        AttributesPermissionsEnricherKey Key,
        Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> Permissions);
}
