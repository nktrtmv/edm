using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data;

public sealed class ApprovalGroupData
{
    internal ApprovalGroupData(
        Id<ApprovalGroup> id,
        string displayName,
        string? label)
    {
        Id = id;
        DisplayName = displayName;
        Label = label;
    }

    public Id<ApprovalGroup> Id { get; }
    public string DisplayName { get; }
    public string? Label { get; }

    public override string ToString()
    {
        return $"{{ Id: {Id}, DisplayName: {DisplayName}, Label: {Label} }}";
    }
}
