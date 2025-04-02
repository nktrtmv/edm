using Edm.Entities.Approval.Rules.Domain.Constants;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.GenericSubdomain.Extensions.Types;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Builders.Stages.Services.Builders.Domestic.Services.
    Participants;

internal static class RouteParticipantBuilder
{
    public static RouteParticipant Build(DomesticApprovalGroupParticipant participant, Entity entity, ApprovalRule approvalRule)
    {
        Id<User> mainPersonId = FetchUserId(participant.MainParticipantSource, entity, approvalRule);

        Id<User>[] substitutePersonsIds = participant.SubstituteParticipantsSources.Select(u => FetchUserId(u, entity, approvalRule)).ToArray();

        var result = new RouteParticipant(mainPersonId, substitutePersonsIds, participant.IsSubstitutionDisabled);

        return result;
    }

    private static Id<User> FetchUserId(DomesticApprovalGroupParticipantSource participantSource, Entity entity, ApprovalRule approvalRule)
    {
        Id<User> result = participantSource switch
        {
            UserDomesticApprovalGroupParticipantSource source => source.UserId,
            AttributeDomesticApprovalGroupParticipantSource source => FetchUserIdFromAttribute(source, entity, approvalRule),
            _ => throw new ArgumentTypeOutOfRangeException(participantSource)
        };

        return result;
    }

    private static Id<User> FetchUserIdFromAttribute(AttributeDomesticApprovalGroupParticipantSource attributeParticipantSource, Entity entity, ApprovalRule approvalRule)
    {
        var attributeValue = entity.GetRequiredAttributeValue<EntityReferenceAttributeValue>(attributeParticipantSource.AttributeId);

        EntityTypeReferenceAttribute attribute =
            TypeCasterTo<EntityTypeReferenceAttribute>.CastRequired(approvalRule.EntityType.Attributes.Single(a => a.Id == attributeValue.Id));

        if (MetadataConverterTo.ToString(attribute.ReferenceTypeId) != ReferenceTypeConstants.Employees)
        {
            throw new ApplicationException("Reference type is not employees");
        }

        if (attributeValue.Value.Length == 0)
        {
            throw new ApplicationException("Attribute values has no one users");
        }

        if (attributeValue.Value.Length > 1)
        {
            throw new ApplicationException("Attribute values has more than one users");
        }

        Id<EntityReferenceAttributeValue> value = attributeValue.Value.Single();

        Id<User> result = IdConverterFrom<User>.From(value);

        return result;
    }
}
