using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts.Groups;

internal static class GetApprovalGraphsQueryResponseGroupInternalConverter
{
    internal static GetApprovalGraphsQueryResponseGroupInternal FromDomain(ApprovalGroup group)
    {
        Id<ApprovalGroupInternal> id = IdConverterFrom<ApprovalGroupInternal>.From(group.Id);

        var result = new GetApprovalGraphsQueryResponseGroupInternal(id, group.DisplayName);

        return result;
    }
}
