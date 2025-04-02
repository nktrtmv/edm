using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts.Graphs;

public sealed class GetAllApprovalGraphsQueryResponseGraphInternal
{
    internal GetAllApprovalGraphsQueryResponseGraphInternal(
        Id<GetAllApprovalGraphsQueryResponseGraphInternal> id,
        ApprovalGraphStatusInternal status,
        string displayName,
        string tag)
    {
        Id = id;
        Status = status;
        DisplayName = displayName;
        Tag = tag;
    }

    public Id<GetAllApprovalGraphsQueryResponseGraphInternal> Id { get; }
    public ApprovalGraphStatusInternal Status { get; }
    public string DisplayName { get; }
    public string Tag { get; }
}
