using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Data;

internal static class ApprovalGroupDataBffConverter
{
    internal static ApprovalGroupDataBff FromDto(ApprovalGroupDataDto group)
    {
        var result = new ApprovalGroupDataBff
        {
            Id = group.Id,
            DisplayName = group.DisplayName,
            Label = group.Label
        };

        return result;
    }

    internal static ApprovalGroupDataDto ToDto(ApprovalGroupDataBff group)
    {
        var result = new ApprovalGroupDataDto
        {
            Id = group.Id,
            DisplayName = group.DisplayName,
            Label = group.Label
        };

        return result;
    }
}
