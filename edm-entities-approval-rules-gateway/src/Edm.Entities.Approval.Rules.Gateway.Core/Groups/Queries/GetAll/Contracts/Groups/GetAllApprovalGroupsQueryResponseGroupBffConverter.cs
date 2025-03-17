using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Groups;

internal static class GetAllApprovalGroupsQueryResponseGroupBffConverter
{
    internal static GetAllApprovalGroupsQueryResponseGroupBff FromDto(GetAllApprovalGroupsQueryResponseGroup group)
    {
        var result = new GetAllApprovalGroupsQueryResponseGroupBff
        {
            Id = group.Id,
            DisplayName = group.DisplayName,
            Label = group.Label
        };

        return result;
    }
}
