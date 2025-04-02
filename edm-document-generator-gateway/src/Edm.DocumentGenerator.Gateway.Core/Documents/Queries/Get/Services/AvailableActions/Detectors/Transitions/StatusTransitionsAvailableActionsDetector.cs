using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.Collections;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Transitions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Detectors.Transitions;

internal static class StatusTransitionsAvailableActionsDetector
{
    internal static DocumentStatusTransitionDetailedBff[] Detect(DocumentAvailableActions context, DocumentDetailedDto document, UserBff user)
    {
        if (context.Signing is not null)
        {
            return [];
        }

        if (context.Approval is not null)
        {
            return [];
        }

        DocumentStatusTransitionDetailedDto[] allowedTransitions = document.AvailableStatusesTransitions
            .Where(t => IsAllowed(t, user, document.AttributesValues))
            .ToArray();

        var result = allowedTransitions.Select(DocumentStatusTransitionDetailedBffConverter.FromDto).ToArray();

        return result;
    }

    private static bool IsAllowed(DocumentStatusTransitionDetailedDto transition, UserBff user, RepeatedField<DocumentAttributeValueDetailedDto> documentAttributesValues)
    {
        if (user.IsAdmin)
        {
            return true;
        }

        var transitionEditPermission = transition.Permissions.FirstOrDefault(p => p.Type == DocumentPermissionTypeDto.Edit);

        if (transitionEditPermission is null)
        {
            return false;
        }

        var hasEditPermissionRole = transitionEditPermission.RoleIds.Intersect(user.Roles).Any();

        var hasEditPermissionAttribute = documentAttributesValues
            .Where(a => transitionEditPermission.AttributeIds.Contains(a.Attribute.Data.Id))
            .SelectMany(a => a.AsReference.Values)
            .Contains(user.Id);

        var userIsAllowed = hasEditPermissionRole || hasEditPermissionAttribute;

        return userIsAllowed;
    }
}
