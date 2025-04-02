using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Keys;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Targets.Generics;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Targets.AttributesPermissions;

internal sealed class AttributesPermissionsEnricherTarget
    : EnricherTargetGeneric<AttributesPermissionsEnricherKey, Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>>
{
    public AttributesPermissionsEnricherTarget(AttributesPermissionsEnricherKey key, DocumentAttributeValueDetailedBff[] target)
    {
        Key = key;
        Target = target;
    }

    private AttributesPermissionsEnricherKey Key { get; }
    public DocumentAttributeValueDetailedBff[] Target { get; }

    public override void CollectKeys(List<AttributesPermissionsEnricherKey> keys)
    {
        keys.Add(Key);
    }

    public override void EnrichTargets(Dictionary<AttributesPermissionsEnricherKey, Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>> values)
    {
        Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> permissions = values[Key];

        foreach (KeyValuePair<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> permission in permissions)
        {
            var attributeValue = Target.FirstOrDefault(t => t.Attribute.Id == permission.Key.Attribute.Id);

            if (attributeValue is null)
            {
                continue;
            }

            attributeValue.Permissions = permission.Value;
        }
    }
}
