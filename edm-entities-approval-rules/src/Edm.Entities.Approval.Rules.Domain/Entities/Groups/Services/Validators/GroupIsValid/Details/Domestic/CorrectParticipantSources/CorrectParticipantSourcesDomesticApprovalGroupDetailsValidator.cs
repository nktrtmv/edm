using Edm.Entities.Approval.Rules.Domain.Constants;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Extensions.Types;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid.Details.Domestic.CorrectParticipantSources;

internal static class CorrectParticipantSourcesDomesticApprovalGroupDetailsValidator
{
    public static void Validate(DomesticApprovalGroupDetails details, ApprovalRule approvalRule)
    {
        DomesticApprovalGroupParticipantSource[] participantSources = details.Participants.SelectMany(p => p.SubstituteParticipantsSources)
            .Concat(details.Participants.Select(p => p.MainParticipantSource))
            .ToArray();

        AttributeDomesticApprovalGroupParticipantSource[] attributeParticipantsSources =
            participantSources.OfType<AttributeDomesticApprovalGroupParticipantSource>().ToArray();

        foreach (AttributeDomesticApprovalGroupParticipantSource attributeParticipantSource in attributeParticipantsSources)
        {
            EntityTypeAttribute attribute = approvalRule.EntityType.Attributes.First(a => a.Id == attributeParticipantSource.AttributeId);

            EntityTypeReferenceAttribute referenceAttribute = TypeCasterTo<EntityTypeReferenceAttribute>.CastRequired(attribute);

            if (MetadataConverterTo.ToString(referenceAttribute.ReferenceTypeId) != ReferenceTypeConstants.Employees)
            {
                throw new ApplicationException(
                    $"""
                     Attribute in participant source doesn't match employees reference type
                     AttributeId: {attribute.Id}
                     """);
            }
        }
    }
}
