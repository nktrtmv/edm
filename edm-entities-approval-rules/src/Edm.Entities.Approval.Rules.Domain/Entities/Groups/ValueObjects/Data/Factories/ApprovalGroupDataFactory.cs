using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data.Factories;

public static class ApprovalGroupDataFactory
{
    public static ApprovalGroupData CreateNew(string displayName)
    {
        var id = Id<ApprovalGroup>.CreateNew();

        ApprovalGroupData result = CreateFromDb(id, displayName, null);

        return result;
    }

    public static ApprovalGroupData CreateFrom(
        Id<ApprovalGroup> id,
        string displayName,
        string label)
    {
        ApprovalGroupData result = CreateFromDb(id, displayName, label);

        return result;
    }

    public static ApprovalGroupData CreateFromDb(
        Id<ApprovalGroup> id,
        string displayName,
        string? label)
    {
        var result = new ApprovalGroupData(id, displayName, label);

        return result;
    }
}
