using Edm.Entities.Approval.Rules.Application.Internal.GroupsDetails.Queries.GetParticipantSourceAttributes.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.GroupsDetails.Domestic.Converters;

internal static class GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseConverter
{
    public static GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponse FromInternal(
        GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseInternal response)
    {
        EntityTypeAttributeDto[] attributes = response.Attributes.Select(EntityTypeAttributeInternalToDtoConverter.ToDto).ToArray();

        var result = new GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponse
        {
            Attributes = { attributes }
        };

        return result;
    }
}
