using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.GroupsDetails.Domestic.Queries.GetParticipantSourceAttributes.Contracts;

internal static class GetParticipantSourceAttributesApprovalGroupsDetailsQueryBffConverter
{
    public static GetParticipantSourceAttributesApprovalGroupsDetailsQuery ToDto(GetParticipantSourceAttributesApprovalGroupsDetailsQueryBff query)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(query.ApprovalRuleKey);

        var result = new GetParticipantSourceAttributesApprovalGroupsDetailsQuery
        {
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
