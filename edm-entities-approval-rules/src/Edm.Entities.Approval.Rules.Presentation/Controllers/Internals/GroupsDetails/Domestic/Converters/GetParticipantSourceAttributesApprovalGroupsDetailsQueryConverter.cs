using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.GroupsDetails.Queries.GetParticipantSourceAttributes.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.GroupsDetails.Domestic.Converters;

internal static class GetParticipantSourceAttributesApprovalGroupsDetailsQueryConverter
{
    public static GetParticipantSourceAttributesApprovalGroupsDetailsQueryInternal ToInternal(GetParticipantSourceAttributesApprovalGroupsDetailsQuery query)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(query.ApprovalRuleKey);

        var result = new GetParticipantSourceAttributesApprovalGroupsDetailsQueryInternal(approvalRuleKey);

        return result;
    }
}
