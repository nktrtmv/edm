using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts;

internal static class GetAllApprovalGroupsQueryResponseInternalConverter
{
    internal static GetAllApprovalGroupsQueryResponseInternal FromDomain(ApprovalGroup[] groups)
    {
        GetAllApprovalGroupsQueryResponseGroupInternal[] groupsInternal =
            groups.Select(GetAllApprovalGroupsQueryResponseGroupInternalConverter.FromDomain).ToArray();

        var result = new GetAllApprovalGroupsQueryResponseInternal(groupsInternal);

        return result;
    }
}
