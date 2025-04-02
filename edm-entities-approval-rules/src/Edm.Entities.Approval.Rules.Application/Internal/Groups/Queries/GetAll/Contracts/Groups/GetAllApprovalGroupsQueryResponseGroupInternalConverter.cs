using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.Groups;

internal static class GetAllApprovalGroupsQueryResponseGroupInternalConverter
{
    internal static GetAllApprovalGroupsQueryResponseGroupInternal FromDomain(ApprovalGroup group)
    {
        Id<GetAllApprovalGroupsQueryResponseGroupInternal> id =
            IdConverterFrom<GetAllApprovalGroupsQueryResponseGroupInternal>.From(group.Data.Id);

        var result = new GetAllApprovalGroupsQueryResponseGroupInternal(id, group.Data.DisplayName, group.Data.Label);

        return result;
    }
}
