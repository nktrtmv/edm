using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Data;

internal static class ApprovalGroupDataInternalConverter
{
    internal static ApprovalGroupDataInternal FromDomain(ApprovalGroupData group)
    {
        Id<ApprovalGroupInternal> id = IdConverterFrom<ApprovalGroupInternal>.From(group.Id);

        var result = new ApprovalGroupDataInternal(id, group.DisplayName, group.Label);

        return result;
    }

    internal static ApprovalGroupData ToDomain(ApprovalGroupDataInternal group)
    {
        Id<ApprovalGroup> id = IdConverterFrom<ApprovalGroup>.From(group.Id);

        ApprovalGroupData result = ApprovalGroupDataFactory.CreateFromDb(id, group.DisplayName, group.Label);

        return result;
    }
}
