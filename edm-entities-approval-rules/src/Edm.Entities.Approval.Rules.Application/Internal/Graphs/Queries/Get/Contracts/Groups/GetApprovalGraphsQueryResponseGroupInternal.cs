using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts.Groups;

public sealed class GetApprovalGraphsQueryResponseGroupInternal
{
    internal GetApprovalGraphsQueryResponseGroupInternal(Id<ApprovalGroupInternal> id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }

    public Id<ApprovalGroupInternal> Id { get; }
    public string DisplayName { get; }
}
