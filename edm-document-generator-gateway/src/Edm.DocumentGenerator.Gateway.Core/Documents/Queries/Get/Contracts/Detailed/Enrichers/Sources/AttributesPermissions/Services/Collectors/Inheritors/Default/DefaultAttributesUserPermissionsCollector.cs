using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Contexts;
using
    Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Inheritors.Default.Read;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Inheritors.Default;

internal sealed class DefaultAttributesUserPermissionsCollector : IAttributesUserPermissionsCollector
{
    private const string AllowAllNoAccessCheck = "allow_all_no_access_check";

    private static readonly DocumentPermissionTypeBff[] AllPermissions = [DocumentPermissionTypeBff.Edit, DocumentPermissionTypeBff.View];

    public Task<Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>> Collect(
        DocumentAttributeValueDetailedBff[] attributesValues,
        AttributesUserPermissionsCollectorContext context,
        CancellationToken cancellationToken)
    {
        var result = new Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>();

        var checkingUserRoles = context.User.Roles.Concat([AllowAllNoAccessCheck]).ToArray();

        var userParticipantAttributeIds = attributesValues
            .Where(
                a => a is DocumentReferenceAttributeValueDetailedBff attributeValueDetailed
                    && attributeValueDetailed.Values.Any(v => v.Id == context.User.Id))
            .Select(a => a.Attribute.Id)
            .ToArray();

        foreach (var attributeValue in attributesValues)
        {
            result[attributeValue] = GetAttributePermissions(attributeValue, context, checkingUserRoles, userParticipantAttributeIds);
        }

        return Task.FromResult(result);
    }

    private static DocumentPermissionTypeBff[] GetAttributePermissions(
        DocumentAttributeValueDetailedBff attributeValue,
        AttributesUserPermissionsCollectorContext context,
        string[] checkingUserRoles,
        string[] userParticipantAttributeIds)
    {
        if (context.User.IsAdmin)
        {
            return AllPermissions;
        }

        var permissions = new List<DocumentPermissionTypeBff>();

        foreach (var permissionConfiguration in attributeValue.Attribute.Permissions)
        {
            if (permissionConfiguration.StatusId != context.Document.Status.Id)
            {
                continue;
            }

            foreach (var permission in permissionConfiguration.Permissions)
            {
                var hasRolePermission = permission.RoleIds.Intersect(checkingUserRoles).Any();

                var hasAttributePermission = permission.AttributeIds.Intersect(userParticipantAttributeIds).Any();

                var hasPermission = hasRolePermission || hasAttributePermission;

                if (hasPermission)
                {
                    permissions.Add(permission.Type);
                }
            }
        }

        if (context.User.IsAuditor)
        {
            permissions.Add(DocumentPermissionTypeBff.View);
        }

        var userHasReadAccess = UserHasReadAccessDetector.Detect(context.Workflows, context.User);

        if (userHasReadAccess)
        {
            permissions.Add(DocumentPermissionTypeBff.View);
        }

        var result = permissions.ToArray();

        return result;
    }
}
