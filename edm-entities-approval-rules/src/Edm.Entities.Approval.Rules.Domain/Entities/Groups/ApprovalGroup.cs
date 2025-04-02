using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups;

public sealed class ApprovalGroup
{
    internal ApprovalGroup(ApprovalGroupData data, ApprovalGroupDetails details)
    {
        Data = data;
        Details = details;
    }

    public ApprovalGroupData Data { get; }
    public ApprovalGroupDetails Details { get; }

    public Id<ApprovalGroup> Id => Data.Id;
    public string DisplayName => Data.DisplayName;
    public string Name => string.IsNullOrWhiteSpace(Data.Label) ? Data.DisplayName : Data.Label;

    public override string ToString()
    {
        return $"{{ Data: {Data}, Details: {Details} }}";
    }
}
