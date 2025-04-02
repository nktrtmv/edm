using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Data;

internal static class ApprovalGroupDataDbConverter
{
    internal static ApprovalGroupDataDb FromDomain(ApprovalGroupData group)
    {
        var id = IdConverterTo.ToString(group.Id);

        var result = new ApprovalGroupDataDb
        {
            Id = id,
            DisplayName = group.DisplayName,
            Label = group.Label
        };

        return result;
    }

    internal static ApprovalGroupData ToDomain(ApprovalGroupDataDb group)
    {
        Id<ApprovalGroup> id = IdConverterFrom<ApprovalGroup>.FromString(group.Id);

        ApprovalGroupData result = ApprovalGroupDataFactory.CreateFrom(id, group.DisplayName, group.Label);

        return result;
    }
}
