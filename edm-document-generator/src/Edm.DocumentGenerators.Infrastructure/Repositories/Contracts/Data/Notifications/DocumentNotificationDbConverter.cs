using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Matches;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Parameters;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications;

internal static class DocumentNotificationDbConverter
{
    internal static DocumentNotificationDb FromDomain(DocumentNotification notification)
    {
        var id = IdConverterTo.ToString(notification.Id);

        DocumentNotificationMatchDb match = DocumentNotificationMatchDbConverter.FromDomain(notification.Match);

        string templateId = IdConverterTo.ToString(notification.TemplateId).ToLower();

        DocumentNotificationParameterDb[] parameters = notification.Parameters.Select(DocumentNotificationParameterDbConverter.FromDomain).ToArray();

        HashSet<string> attributesRecipientIds = notification.RecipientAttributeIds.Select(x => x.ToString()).ToHashSet();
        HashSet<string> rolesRecipientIds = notification.RecipientRoles.Select(x => x.Value).ToHashSet();

        var result = new DocumentNotificationDb
        {
            Id = id,
            Match = match,
            TemplateId = templateId,
            Parameters = { parameters },
            RecipientAttributeIds = { attributesRecipientIds },
            RecipientRoles = { rolesRecipientIds },
#pragma warning disable CS0612 // Type or member is obsolete
            RecipientAttributeId = attributesRecipientIds.FirstOrDefault() ?? ""
#pragma warning restore CS0612 // Type or member is obsolete
        };

        return result;
    }

    internal static DocumentNotification ToDomain(DocumentNotificationDb notification)
    {
        Id<DocumentNotification> id = IdConverterFrom<DocumentNotification>.FromString(notification.Id);

        DocumentNotificationMatch match = DocumentNotificationMatchDbConverter.ToDomain(notification.Match);

        #region backward compitibility

        // TODO: REMOVE: This is for backward compatability (Number and NumberContract shall be mapped to DocumentNumber).

        string originalNotificationTemplateId = notification.TemplateId;

        string mappedNotificationTemplateId = originalNotificationTemplateId switch
        {
            "a0f7a4b6-b02a-44d0-9721-3bb685ceee49" => "cd000001-f22a-4c1c-b8e5-40a9cdff016c",
            "b3f0b1a3-e586-4c1a-b8d4-624ae53bd2df" => "cd000002-f22a-4c1c-b8e5-40a9cdff016c",
            "dbd80c78-cc9a-44e0-9c14-0a808b0243b7" => "cd000003-f22a-4c1c-b8e5-40a9cdff016c",
            "e313d0b0-c109-4342-8a89-00892e0467aa" => "cd000004-f22a-4c1c-b8e5-40a9cdff016c",
            "1703291c-3bc4-4774-994e-1f3a1354582d" => "cd000005-f22a-4c1c-b8e5-40a9cdff016c",
            "6559da53-7c85-45f3-827c-eefe8db72965" => "cd000006-f22a-4c1c-b8e5-40a9cdff016c",
            "4ae92957-9220-46c7-bb0f-2c27106bc70c" => "cd000007-f22a-4c1c-b8e5-40a9cdff016c",
            "30f959a2-6c75-4075-9fb2-7987b5a9b962" => "cd000008-f22a-4c1c-b8e5-40a9cdff016c",
            "47cb1fe7-8e8f-4cf9-b8a3-8091376408cd" => "cd000009-f22a-4c1c-b8e5-40a9cdff016c",

            "63a4f983-e632-485d-b42b-669ce02f6112" => "cd000012-f22a-4c1c-b8e5-40a9cdff016c",
            "7355986b-96be-40ca-bcdf-3943a5748698" => "cd000013-f22a-4c1c-b8e5-40a9cdff016c",
            "500d6618-0463-4c9c-8301-723345b5d154" => "cd000014-f22a-4c1c-b8e5-40a9cdff016c",
            "68AFC098-9F9F-4F18-BEFA-914AB969D977" => "cd000015-f22a-4c1c-b8e5-40a9cdff016c",
            _ => originalNotificationTemplateId
        };

        #endregion

        mappedNotificationTemplateId = mappedNotificationTemplateId.ToLower();

        Id<NotificationTemplate> templateId = IdConverterFrom<NotificationTemplate>.FromString(mappedNotificationTemplateId);

        DocumentNotificationParameter[] parameters = notification.Parameters.Select(DocumentNotificationParameterDbConverter.ToDomain).ToArray();

        // TODO: REMOVE: This is for backward compatability (Number and NumberContract shall be mapped to DocumentNumber).

        DocumentNotificationParameter[] distinctParameters = parameters
            .GroupBy(p => p.TemplateParameterId)
            .Select(p => p.First())
            .ToArray();

        HashSet<Role> recipientRolesIds = notification.RecipientRoles.Select(x => new Role(x)).ToHashSet();

#pragma warning disable CS0612 // Type or member is obsolete
        HashSet<Id<DocumentAttribute>> recipientAttributesIds = notification.RecipientAttributeIds
            .Concat([notification.RecipientAttributeId])
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(IdConverterFrom<DocumentAttribute>.FromString)
            .ToHashSet();
#pragma warning restore CS0612 // Type or member is obsolete

        var result = new DocumentNotification(id, match, templateId, distinctParameters, recipientAttributesIds, recipientRolesIds);

        return result;
    }
}
