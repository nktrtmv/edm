using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Data;

public sealed class ApprovalGroupDataInternal
{
    public ApprovalGroupDataInternal(
        Id<ApprovalGroupInternal> id,
        string displayName,
        string? label)
    {
        Id = id;
        DisplayName = displayName;
        Label = label;
    }

    public Id<ApprovalGroupInternal> Id { get; }
    public string DisplayName { get; }
    public string? Label { get; }
}
