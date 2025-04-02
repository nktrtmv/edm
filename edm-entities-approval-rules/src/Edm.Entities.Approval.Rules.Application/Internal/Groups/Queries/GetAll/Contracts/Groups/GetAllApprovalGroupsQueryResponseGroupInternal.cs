using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.Groups;

public sealed class GetAllApprovalGroupsQueryResponseGroupInternal
{
    internal GetAllApprovalGroupsQueryResponseGroupInternal(
        Id<GetAllApprovalGroupsQueryResponseGroupInternal> id,
        string displayName,
        string? label)
    {
        Id = id;
        DisplayName = displayName;
        Label = label;
    }

    public Id<GetAllApprovalGroupsQueryResponseGroupInternal> Id { get; }
    public string DisplayName { get; }
    public string? Label { get; }
}
