using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors;

internal interface IAttributesUserPermissionsCollector
{
    Task<Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>> Collect(
        DocumentAttributeValueDetailedBff[] attributesValues,
        AttributesUserPermissionsCollectorContext context,
        CancellationToken cancellationToken);
}
