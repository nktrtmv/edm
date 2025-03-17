using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.GroupsDetails.Domestic.Queries.GetParticipantSourceAttributes.Contracts;

internal static class GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseBffConverter
{
    public static GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseBff FromDto(GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponse response)
    {
        EntityTypeAttributeBff[] attributes = response.Attributes.Select(EntityTypeAttributeBffConverter.FromDto).ToArray();

        var result = new GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseBff(attributes);

        return result;
    }
}
