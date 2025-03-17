using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.Get;

internal static class GetApprovalGroupsQueryInternalConverter
{
    internal static GetApprovalGroupsQueryInternal FromDto(GetApprovalGroupsQuery query)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(query.ApprovalRuleKey);

        Id<ApprovalGroupInternal> groupId = IdConverterFrom<ApprovalGroupInternal>.FromString(query.GroupId);

        var result = new GetApprovalGroupsQueryInternal(approvalRuleKey, groupId);

        return result;
    }
}
