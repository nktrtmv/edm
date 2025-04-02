using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Data;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Data;

internal static class ApprovalGroupDataInternalConverter
{
    internal static ApprovalGroupDataInternal FromDto(ApprovalGroupDataDto group)
    {
        Id<ApprovalGroupInternal> id = IdConverterFrom<ApprovalGroupInternal>.FromString(group.Id);

        var result = new ApprovalGroupDataInternal(id, group.DisplayName, group.Label);

        return result;
    }

    internal static ApprovalGroupDataDto ToDto(ApprovalGroupDataInternal group)
    {
        var id = IdConverterTo.ToString(group.Id);

        var result = new ApprovalGroupDataDto
        {
            Id = id,
            DisplayName = group.DisplayName,
            Label = group.Label
        };

        return result;
    }
}
